using System;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Rules for checking out items.
    /// Preconditions: inputs are not null.
    /// Postconditions: returns a decision based on the policy.
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
        /// Checks if a due date is valid for this item.
        /// Preconditions: item is not null.
        /// Postconditions: returns true if dueDate fits the rules.
        /// </summary>
        /// <param name="item">Item being checked out.</param>
        /// <param name="checkoutTime">Checkout time.</param>
        /// <param name="dueDate">Requested due date.</param>
        /// <returns>True if due date is valid.</returns>
        bool IsDueDateValid(EquipmentItem item, DateTime checkoutTime, DateTime dueDate);
    }
}