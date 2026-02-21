namespace ITCS_3112_Lab_1_Checkout.Domain
{
    /// <summary>
    /// Represents a item in the catalog to be checked out.
    /// </summary>
    public class EquipmentItem
    {
        public string Id { get; }
        public string Name { get; }
        public string Category { get; }
        public ItemCondition Condition { get; private set; }
        public ItemStatus Status { get; private set; }

        public EquipmentItem(string id, string name, string category, ItemCondition condition)
        {
            Id = id;
            Name = name;
            Category = category;
            Condition = condition;
            Status = ItemStatus.Available;
        }

        /// <summary>
        /// Marks the item as available.
        /// Postconditions: Status is Available.
        /// </summary>
        public void MarkAvailable() => Status = ItemStatus.Available;
        
        /// <summary>
        /// Marks the item as checked out.
        /// Postconditions: Status is CheckedOut.
        /// </summary>
        public void MarkCheckedOut() => Status = ItemStatus.CheckedOut;
        
        /// <summary>
        /// Marks the item as lost.
        /// Postconditions: Status is Lost.
        /// </summary>
        public void MarkLost() => Status = ItemStatus.Lost;

        /// <summary>
        /// Updates the condition of the item.
        /// Preconditions: newCondition is a valid ItemCondition.
        /// Postconditions: Condition is updated to newCondition.
        /// </summary>
        /// <param name="newCondition">The new condition of the item.</param>
        public void UpdateCondition(ItemCondition newCondition) => Condition = newCondition;

        public override string ToString() => $"{Id} | {Name} | {Category} | {Condition} | {Status}";
    }
}