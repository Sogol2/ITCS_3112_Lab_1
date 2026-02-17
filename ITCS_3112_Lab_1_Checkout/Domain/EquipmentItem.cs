namespace ITCS_3112_Lab_1_Checkout.Domain
{
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

        public void MarkAvailable() => Status = ItemStatus.Available;
        public void MarkCheckedOut() => Status = ItemStatus.CheckedOut;
        public void MarkLost() => Status = ItemStatus.Lost;

        public void UpdateCondition(ItemCondition newCondition) => Condition = newCondition;

        public override string ToString() => $"{Id} | {Name} | {Category} | {Condition} | {Status}";
    }
}