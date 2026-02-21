namespace ITCS_3112_Lab_1_Checkout.Domain
{
    /// <summary>
    /// Represents a record of an item checked out by a user.
    /// </summary>
    public class CheckoutRecord
    {
        public string ItemId { get; }
        public string BorrowerId { get; }
        public Borrower Borrower { get; }

        public DateTime CheckoutDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnedDate { get; private set; }
        
        public bool IsReturned => ReturnedDate.HasValue;

        public CheckoutRecord(string itemId, Borrower borrower, DateTime checkoutDate, DateTime dueDate)
        {
            ItemId = itemId;
            Borrower = borrower;
            BorrowerId = borrower.Id;
            CheckoutDate = checkoutDate;
            DueDate = dueDate;
        }

        /// <summary>
        /// Marks the checkout as returned.
        /// Preconditions: item has not been returned.
        /// Postconditions: ReturnedDate is set to the given return time.
        /// </summary>
        /// <param name="returnTime">The date and time the item was returned.</param>
        public void MarkReturned(DateTime returnTime)
        {
            if (!ReturnedDate.HasValue)
                ReturnedDate = returnTime;
        }
    }
}