using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Repositories;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

/// <summary>
/// Stores and retrieves items + checkout records (data layer).
/// Preconditions: IDs are not null/empty, objects are not null.
/// Postconditions: saved data can be retrieved later.
/// </summary>
public class Repository : IRepository
{
    public List<CheckoutRecord> Records;
    
    /// <summary>
    /// Adds an item or updates it if the ID already exists.
    /// Preconditions: item not null, item.Id not null/empty.
    /// Postconditions: repository has an item with this ID.
    /// </summary>
    /// <param name="item">Item to save.</param>
    public void UpsertItem(EquipmentItem item)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Gets an item by ID (any status).
    /// Preconditions: itemId not null/empty.
    /// Postconditions: returns item or null if missing.
    /// </summary>
    /// <param name="itemId">Item ID.</param>
    /// <returns>The item or null.</returns>
    public EquipmentItem? GetItem(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets all items.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>All items.</returns>
    public IReadOnlyList<EquipmentItem> GetAllItems()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Saves a checkout record.
    /// Preconditions: record not null.
    /// Postconditions: record is stored for later lookup.
    /// </summary>
    /// <param name="record">Record to save.</param>
    public void AddRecord(CheckoutRecord record)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets all checkout records (active + returned).
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>All records.</returns>
    public IReadOnlyList<CheckoutRecord> GetAllRecords()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets records for a borrower.
    /// Preconditions: borrowerId not null/empty.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <param name="borrowerId">Borrower ID.</param>
    /// <returns>Records for that borrower.</returns>
    public IReadOnlyList<CheckoutRecord> GetRecordsByBorrower(string borrowerId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets records for an item.
    /// Preconditions: itemId not null/empty.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <param name="itemId">Item ID.</param>
    /// <returns>Records for that item.</returns>
    public IReadOnlyList<CheckoutRecord> GetRecordsByItem(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the active record for an item (not returned yet).
    /// Preconditions: itemId not null/empty.
    /// Postconditions: returns record or null if none active.
    /// </summary>
    /// <param name="itemId">Item ID.</param>
    /// <returns>Active record or null.</returns>
    public CheckoutRecord? GetActiveRecordByItem(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks an item as returned (updates active record).
    /// Preconditions: itemId not null/empty.
    /// Postconditions: if an active record exists, it becomes returned.
    /// </summary>
    /// <param name="itemId">Item ID.</param>
    /// <param name="returnTime">Return time.</param>
    public void MarkReturned(string itemId, DateTime returnTime)
    {
        throw new NotImplementedException();
    }
}