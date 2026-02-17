using System;

namespace ITCS_3112_Lab_1_Checkout.Domain
{
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

        public void MarkReturned(DateTime returnTime)
        {
            if (!ReturnedDate.HasValue)
                ReturnedDate = returnTime;
        }
    }
}