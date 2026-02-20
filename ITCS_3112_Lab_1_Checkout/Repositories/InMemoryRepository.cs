using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories
{
    /// <summary>
    /// Simple in-memory storage for items and checkout records.
    /// Preconditions: inputs are not null, IDs are not empty.
    /// Postconditions: saved data can be retrieved later.
    /// </summary>
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<string, EquipmentItem> _items = new();
        private readonly List<CheckoutRecord> _records = new();

        /// <summary>
        /// Adds an item or updates it if the ID already exists.
        /// Preconditions: item not null, item.Id not null/empty.
        /// Postconditions: repository has an item with this ID.
        /// </summary>
        /// <param name="item">Item to save.</param>
        public void UpsertItem(EquipmentItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.Id)) throw new ArgumentException("Item must have an ID.");

            _items[item.Id] = item;
        }

        /// <summary>
        /// Gets an item by ID (any status).
        /// Preconditions: itemId not null/empty.
        /// Postconditions: returns item or null if missing.
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        /// <returns>The item or null.</returns>
        public EquipmentItem? GetItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

            _items.TryGetValue(itemId, out var item);
            return item;
        }

        /// <summary>
        /// Gets all items.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>All items in a list.</returns>
        public IReadOnlyList<EquipmentItem> GetAllItems()
        {
            return _items.Values.ToList();
        }

        /// <summary>
        /// Saves a checkout record.
        /// Preconditions: record not null.
        /// Postconditions: record is stored for later lookup.
        /// </summary>
        /// <param name="record">Record to save.</param>
        public void AddRecord(CheckoutRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            _records.Add(record);
        }

        public IReadOnlyList<CheckoutRecord> GetAllRecords()
        {
            return _records.ToList();
        }

        /// <summary>
        /// Gets all checkout records (active + returned).
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>All records.</returns>
        public IReadOnlyList<CheckoutRecord> GetRecordsByBorrower(string borrowerId)
        {
            if (string.IsNullOrWhiteSpace(borrowerId)) throw new ArgumentException("borrowerId is required.");

            return _records
                .Where(r => r.BorrowerId == borrowerId)
                .ToList();
        }

        /// <summary>
        /// Gets records for an item.
        /// Preconditions: itemId not null/empty.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        /// <returns>Records for that item.</returns>
        public IReadOnlyList<CheckoutRecord> GetRecordsByItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

            return _records
                .Where(r => r.ItemId == itemId)
                .ToList();
        }

        /// <summary>
        /// Gets the active record for an item (not returned yet).
        /// Preconditions: itemId not null/empty.
        /// Postconditions: returns record or null if none active.
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        /// <returns>Active record or null.</returns>
        public CheckoutRecord? GetActiveRecordByItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

           
            return _records.LastOrDefault(r => r.ItemId == itemId && !r.IsReturned);
        }

        /// <summary>
        /// Marks an item as returned (updates active record).
        /// Preconditions: itemId not null/empty.
        /// Postconditions: if an active record exists, it becomes returned.
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        /// <param name="returnTime">Return time.</param>
        public void MarkReturned(string itemId, DateTime returnTime)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

            var active = GetActiveRecordByItem(itemId);
            if (active != null)
            {
                active.MarkReturned(returnTime);
            }
        }
    }
}
