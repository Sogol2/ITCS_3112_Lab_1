namespace ITCS_3112_Lab_1_Checkout.Domain
{
    /// <summary>
    /// Represents a receipt made for checkout or return.
    /// </summary>
    public class Receipt
    {
        public string Title { get; }
        public string ItemId { get; }
        public string ItemName { get; }
        public string BorrowerName { get; }
        public DateTime Timestamp { get; }
        public DateTime? DueDate { get; }

        public Receipt(
            string title, 
            string itemId, 
            string itemName, 
            string borrowerName, 
            DateTime timestamp, 
            DateTime? dueDate)
        {
            Title = title;
            ItemId = itemId;
            ItemName = itemName;
            BorrowerName = borrowerName;
            Timestamp = timestamp;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            var dueText = DueDate.HasValue ? $"Due: {DueDate.Value:g}" : "Due: N/A";
            return $"{Title}\nItem: {ItemId} - {ItemName}\nBorrower: {BorrowerName}\nTime: {Timestamp:g}\n{dueText}";
        }
    }
}