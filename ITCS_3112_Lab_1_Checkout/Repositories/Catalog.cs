namespace ITCS_3112_Lab_1_Checkout.Repositories;

/// <summary>
/// 
/// </summary>
public class Catalog
{
    public List<Item> Items;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="category"></param>
    /// <param name="condition"></param>
    public void AddItem(string id, string name, string category, ItemCondition condition)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Item> ListAvailable()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemid"></param>
    /// <returns></returns>
    public Item? FindById(string itemid)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public IReadOnlyList<Item> SearchBy(string query)
    {
        throw new NotImplementedException();
    }
}