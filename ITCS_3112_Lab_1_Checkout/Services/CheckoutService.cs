using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Repositories;


namespace ITCS_3112_Lab_1_Checkout.Services;

/// <summary>
/// Handles the main checkout actions (checkout, return, due soon, overdue).
/// </summary>
public class CheckoutService : ICheckoutService
{
    private readonly IRepository _repository;
    private readonly IPolicy _policy;
    private readonly INotifier _notifier;
    private readonly IClock _clock;
    
    public CheckoutService(IRepository repo, IPolicy policy, INotifier notifier, IClock clock)
    {
        _repository = repo;
        _policy = policy;
        _notifier = notifier;
        _clock = clock;
    }
    
    /// <summary>
    /// Gets the catalog so the UI can list/search items.
    /// Preconditions: none.
    /// Postconditions: returns a non-null catalog.
    /// </summary>
    /// <returns>The catalog.</returns>
    public ICatalog GetCatalog()
    {
        return new Catalog(_repository);
    }

    /// <summary>
    /// Checks out an item and returns a receipt.
    /// Preconditions: itemId not null/empty, borrower not null, dueDate after now.
    /// Postconditions: item becomes checked out and a new active record is saved.
    /// </summary>
    /// <param name="itemId">Item ID to check out.</param>
    /// <param name="borrower">Student borrowing the item.</param>
    /// <param name="dueDate">When the item is due back.</param>
    /// <returns>Checkout receipt.</returns>
    public Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate)
    {
        var item = _repository.GetItem(itemId);
        DateTime normalizedDueDate = _policy.NormalizeDueDate(dueDate);

        if (item == null)
            throw new InvalidOperationException($"Item {itemId} not found.");
        
        if (!_policy.CanCheckout(item))
            throw new InvalidOperationException($"Item {itemId} is not available for checkout.");
        
        item.MarkCheckedOut();
        
        var record = new CheckoutRecord(itemId, borrower, _clock.Now, normalizedDueDate);
        _repository.AddRecord(record);
        _repository.UpsertItem(item);
        
        return new Receipt("Checkout", item.Id, item.Name, borrower.Name, _clock.Now, normalizedDueDate);
    }

    /// <summary>
    /// Returns an item and returns a receipt.
    /// Preconditions: itemId not null/empty and item has an active checkout record.
    /// Postconditions: item becomes available and the record is marked returned.
    /// </summary>
    /// <param name="itemId">Item ID to return.</param>
    /// <returns>Return receipt.</returns>
    public Receipt ReturnItem(string itemId)
    {
        var item = _repository.GetItem(itemId);
        var record = _repository.GetActiveRecordByItem(itemId);
        
        if (item == null)
            throw new InvalidOperationException($"Item {itemId} not found.");
        
        if (record == null)
            throw new InvalidOperationException($"Item {itemId} has no active checkout.");

        _repository.MarkReturned(itemId, _clock.Now);
        item.MarkAvailable();
        _repository.UpsertItem(item);
        
        return new Receipt("Return", item.Id, item.Name, record.Borrower.Name, _clock.Now, null);
    }

    /// <summary>
    /// Marks an item as lost.
    /// Preconditions: itemId not null/empty.
    /// Postconditions: item status becomes Lost.
    /// </summary>
    /// <param name="itemId">Item ID to mark lost.</param>
    public void MarkLost(string itemId)
    {
        var item = _repository.GetItem(itemId);
    
        if (item == null)
            throw new InvalidOperationException($"Item {itemId} not found.");
        
        item.MarkLost();
        _repository.UpsertItem(item);
    }

    /// <summary>
    /// Finds loans that are due soon.
    /// Preconditions: window > 0.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <param name="window">How far ahead to look.</param>
    /// <returns>Records due soon.</returns>
    public IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        var records = _repository.GetAllRecords()
            .Where(r => !r.IsReturned && r.DueDate <= _clock.Now + window)
            .ToList();

        foreach (var record in records)
            _notifier.NotifyDueSoon(record);

        return records;
    }

    /// <summary>
    /// Finds loans that are overdue.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>Overdue records.</returns>
    public IReadOnlyList<CheckoutRecord> FindOverdue()
    {
        var records = _repository.GetAllRecords()
            .Where(r => !r.IsReturned && r.DueDate < _clock.Now)
            .ToList();

        foreach (var record in records)
            _notifier.NotifyOverdue(record);

        return records;
    }
}
    
    