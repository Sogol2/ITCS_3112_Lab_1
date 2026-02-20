using System;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Rules for checking out items.
    /// </summary>
    public interface IPolicy
    {
        /// <summary>
        /// Checks if this borrower is allowed to check out this item.
        /// Preconditions: item and borrower are not null.
        /// Postconditions: returns true if allowed, otherwise false.
        /// </summary>
        /// <param name="item">Item being requested.</param>
        /// <param name="borrower">Borrower requesting the item.</param>
        /// <returns>True if checkout is allowed.</returns>
        bool CanCheckout(EquipmentItem item, Borrower borrower);

        /// <summary>
        /// Returns the max loan time for an item.
        /// Preconditions: item is not null.
        /// Postconditions: returns a positive TimeSpan.
        /// </summary>
        /// <param name="item">Item being loaned.</param>
        /// <returns>Maximum loan duration.</returns>
        TimeSpan GetMaxLoanDuration(EquipmentItem item);

        /// <summary>
        /// Calculates the appropriate due date for an item based on checkout policies.
        /// Preconditions: proposed must not be null.
        /// Postconditions: returns a positive DateTime.
        /// </summary>
        /// <param name="proposed">The date and time when the item is checked out.</param>
        /// <returns>Normalized due date that complies with all checkout policies.</returns>
        DateTime NormalizeDueDate(DateTime proposed);
    }
}