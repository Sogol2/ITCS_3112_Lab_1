namespace ITCS_3112_Lab_1_Checkout.Repositories;

/// <summary>
/// 
/// </summary>
public class RecordRepository
{
    public List<CheckoutRecord> Records;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public Item? GetItem(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Item> AllItems()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="record"></param>
    public void SaveRcord(CheckoutRecord record)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public CheckoutRecord? GetActiveRecordFor(string itemId)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<CheckoutRecord> AllRecords()
    {
        throw new NotImplementedException();
    }
    
}