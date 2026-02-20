using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Contracts;

namespace ITCS_3112_Lab_1_Checkout.Services;

/// <summary>
/// Sends messages to borrowers for due-soon and overdue items.
/// </summary>
public class Notifier : INotifier
{
    /// <summary>
    /// Alerts the borrower that the item is due soon.
    /// Preconditions: record is not null.
    /// Postconditions: notification is attempted.
    /// </summary>
    /// <param name="record">Checkout record that is due soon.</param>
    public void NotifyDueSoon(CheckoutRecord record)
    {
        Console.WriteLine($"NOTICE: Item {record.ItemId} " +
                          $"borrowed by {record.Borrower.Name} ({record.Borrower.Email}) is due soon.");
    }    
    
    /// <summary>
    /// Alerts the borrower that the item is overdue.
    /// Preconditions: record is not null.
    /// Postconditions: notification is attempted.
    /// </summary>
    /// <param name="record">Checkout record that is overdue.</param>
    public void NotifyOverdue(CheckoutRecord record)
    {
        Console.WriteLine($"NOTICE: Item {record.ItemId} borrowed by " +
                          $"{record.Borrower.Name} ({record.Borrower.Email}) is overdue.");
    }
}