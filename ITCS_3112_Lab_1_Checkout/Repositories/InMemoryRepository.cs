using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpsertItem(EquipmentItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.Id)) throw new ArgumentException("Item must have an ID.");

            _items[item.Id] = item;
        }

        public EquipmentItem? GetItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

            _items.TryGetValue(itemId, out var item);
            return item;
        }

        public IReadOnlyList<EquipmentItem> GetAllItems()
        {
            return _items.Values.ToList();
        }

        public void AddRecord(CheckoutRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            _records.Add(record);
        }

        public IReadOnlyList<CheckoutRecord> GetAllRecords()
        {
            return _records.ToList();
        }

        public IReadOnlyList<CheckoutRecord> GetRecordsByBorrower(string borrowerId)
        {
            if (string.IsNullOrWhiteSpace(borrowerId)) throw new ArgumentException("borrowerId is required.");

            return _records
                .Where(r => r.BorrowerId == borrowerId)
                .ToList();
        }

        public IReadOnlyList<CheckoutRecord> GetRecordsByItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

            return _records
                .Where(r => r.ItemId == itemId)
                .ToList();
        }

        public CheckoutRecord? GetActiveRecordByItem(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException("itemId is required.");

           
            return _records.LastOrDefault(r => r.ItemId == itemId && !r.IsReturned);
        }

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
