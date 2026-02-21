namespace ITCS_3112_Lab_1_Checkout.Domain
{
    /// <summary>
    /// Represents a user who borrows items from the catalog.
    /// </summary>
    public class Borrower
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }

        public Borrower(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        
        public override string ToString() => $"{Name} ({Id}) - {Email}";
    }
}