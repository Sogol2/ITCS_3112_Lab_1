using System;
using System.Collections.Generic;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Handles the main checkout actions (checkout, return, due soon, overdue).
    /// Preconditions: service is set up with needed parts (repo/policy/clock/etc.).
    /// Postconditions: if an action succeeds, item status + records are updated.
    /// </summary>
    public interface ICheckoutService
    {
        /// <summary>
        /// Gets the catalog so the UI can list/search items.
        /// Preconditions: none.
        /// Postconditions: returns a non-null catalog.
        /// </summary>
        /// <returns>The catalog.</returns>
        ICatalog GetCatalog();

        /// <summary>
        /// Checks out an item and returns a receipt.
        /// Preconditions: itemId not null/empty, borrower not null, dueDate after now.
        /// Postconditions: item becomes checked out and a new active record is saved.
        /// </summary>
        /// <param name="itemId">Item ID to check out.</param>
        /// <param name="borrower">Student borrowing the item.</param>
        /// <param name="dueDate">When the item is due back.</param>
        /// <returns>Checkout receipt.</returns>
        Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);

        /// <summary>
        /// Returns an item and returns a receipt.
        /// Preconditions: itemId not null/empty and item has an active checkout record.
        /// Postconditions: item becomes available and the record is marked returned.
        /// </summary>
        /// <param name="itemId">Item ID to return.</param>
        /// <returns>Return receipt.</returns>
        Receipt ReturnItem(string itemId);

        /// <summary>
        /// Marks an item as lost.
        /// Preconditions: itemId not null/empty.
        /// Postconditions: item status becomes Lost.
        /// </summary>
        /// <param name="itemId">Item ID to mark lost.</param>
        void MarkLost(string itemId);

        /// <summary>
        /// Lists all active loans (not returned yet).
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>Active checkout records.</returns>
        IReadOnlyList<CheckoutRecord> ListActiveLoans();

        /// <summary>
        /// Finds loans that are due soon.
        /// Preconditions: window > 0.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <param name="window">How far ahead to look.</param>
        /// <returns>Records due soon.</returns>
        IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window);

        /// <summary>
        /// Finds loans that are overdue.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>Overdue records.</returns>
        IReadOnlyList<CheckoutRecord> FindOverdue();
    }
}
