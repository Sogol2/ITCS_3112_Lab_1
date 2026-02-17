namespace ITCS_3112_Lab_1_Checkout.Services;

/// <summary>
/// 
/// </summary>
public class CheckoutService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<CheckoutRecord> FindOverdue()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ICatalog GetCatalog()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ItemId"></param>
    /// <param name="borrower"></param>
    /// <param name="dueDate"></param>
    /// <returns></returns>
    public Receipt CheckoutItem(string ItemId, Borrower borrower, DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ItemId"></param>
    /// <returns></returns>
    public Receipt ReturnItem(string ItemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ItemId"></param>
    public void MarkLost(string ItemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<CheckoutRecord> ListActiveLoans()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="window"></param>
    /// <returns></returns>
    public IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        throw new NotImplementedException();
    }
}
    
    