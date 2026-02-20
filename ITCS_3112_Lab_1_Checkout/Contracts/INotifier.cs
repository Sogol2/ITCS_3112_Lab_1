using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Sends messages to borrowers for due-soon and overdue items.
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Alerts the borrower that the item is due soon.
        /// Preconditions: record is not null.
        /// Postconditions: notification is attempted.
        /// </summary>
        /// <param name="record">Checkout record that is due soon.</param>
        void NotifyDueSoon(CheckoutRecord record);

        /// <summary>
        /// Alerts the borrower that the item is overdue.
        /// Preconditions: record is not null.
        /// Postconditions: notification is attempted.
        /// </summary>
        /// <param name="record">Checkout record that is overdue.</param>
        void NotifyOverdue(CheckoutRecord record);
    }
}