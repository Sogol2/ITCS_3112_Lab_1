using ITCS_3112_Lab_1_Checkout.Contracts;

namespace ITCS_3112_Lab_1_Checkout.Services;

/// <summary>
/// Gives the current time for the app.
/// Preconditions: none.
/// Postconditions: returns a valid DateTime for "now".
/// </summary>
public class Clock : IClock
{
    public Clock() {}
    
    /// <summary>
    /// Current time used by the system.
    /// Preconditions: none.
    /// Postconditions: returns a valid DateTime.
    /// </summary>
    public DateTime Now => DateTime.Now;
}