using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Services;

/// <summary>
/// Rules for checking out items.
/// </summary>
public class Policy : IPolicy
{
    private readonly IClock _clock;

    public Policy(IClock clock)
    {
        _clock = clock;
    }
    
    /// <summary>
    /// Checks if this item is allowed to be checked out.
    /// Preconditions: item and borrower are not null.
    /// Postconditions: returns true if allowed, otherwise false.
    /// </summary>
    /// <param name="item">Item being requested.</param>
    /// <returns>True if checkout is allowed.</returns>
    public bool CanCheckout(EquipmentItem item)
    {
        return item.Status == ItemStatus.Available;
    }
    
    /// <summary>
    /// Calculates the appropriate due date for an item based on checkout policies.
    /// Preconditions: proposed must not be null.
    /// Postconditions: returns a positive DateTime.
    /// </summary>
    /// <param name="proposed">The date and time when the item is checked out.</param>
    /// <returns>Normalized due date that complies with all checkout policies.</returns>
    public DateTime NormalizeDueDate(DateTime proposed)
    {
        DateTime max = _clock.Now.AddDays(14);
        return proposed > max ? max : proposed;
    }
}