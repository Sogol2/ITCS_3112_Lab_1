using System.Collections.Generic;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Contracts;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

/// <summary>
/// Search the inventory.
/// </summary>
public class Catalog : ICatalog
{
    public List<EquipmentItem> Items;

    /// <summary>
    /// Gets one item by its ID.
    /// Preconditions: itemId is not null/empty.
    /// Postconditions: returns the item or null if not found.
    /// </summary>
    /// <param name="itemId">Item ID to look up.</param>
    /// <returns>The item if it exists, otherwise null.</returns>
    public EquipmentItem? GetById(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lists every item in the system.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>All items.</returns>
    public IReadOnlyList<EquipmentItem> ListAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lists items that are available.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>Available items.</returns>
    public IReadOnlyList<EquipmentItem> ListAvailable()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lists items that are checked out.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>Checked out items.</returns>
    public IReadOnlyList<EquipmentItem> ListCheckedOut()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lists items that are marked lost.
    /// Preconditions: none.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <returns>Lost items.</returns>
    public IReadOnlyList<EquipmentItem> ListLost()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Searches items by keyword (like ID, name, or category).
    /// Preconditions: keyword is not null/empty.
    /// Postconditions: returns a non-null list (can be empty).
    /// </summary>
    /// <param name="keyword">Text to search for.</param>
    /// <returns>Matching items (or empty list).</returns>
    public IReadOnlyList<EquipmentItem> Search(string keyword)
    {
        throw new NotImplementedException();
    }
}