using System.Collections.Generic;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Program view and search the inventory.
    /// Preconditions: none.
    /// Postconditions: methods do not change items.
    /// </summary>
    public interface ICatalog
    {
        /// <summary>
        /// Gets one item by its ID.
        /// Preconditions: itemId is not null/empty.
        /// Postconditions: returns the item or null if not found.
        /// </summary>
        /// <param name="itemId">Item ID to look up.</param>
        /// <returns>The item if it exists, otherwise null.</returns>
        EquipmentItem? GetById(string itemId);

        /// <summary>
        /// Lists every item in the system.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>All items.</returns>
        IReadOnlyList<EquipmentItem> ListAll();

        /// <summary>
        /// Lists items that are available.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>Available items.</returns>
        IReadOnlyList<EquipmentItem> ListAvailable();

        /// <summary>
        /// Lists items that are checked out.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>Checked out items.</returns>
        IReadOnlyList<EquipmentItem> ListCheckedOut();

        /// <summary>
        /// Lists items that are marked lost.
        /// Preconditions: none.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <returns>Lost items.</returns>
        IReadOnlyList<EquipmentItem> ListLost();

        /// <summary>
        /// Searches items by keyword (like ID, name, or category).
        /// Preconditions: keyword is not null/empty.
        /// Postconditions: returns a non-null list (can be empty).
        /// </summary>
        /// <param name="keyword">Text to search for.</param>
        /// <returns>Matching items (or empty list).</returns>
        IReadOnlyList<EquipmentItem> Search(string keyword);
    }
}
