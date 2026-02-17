using System;

namespace ITCS_3112_Lab_1_Checkout.Contracts
{
    /// <summary>
    /// Gives the current time for the app.
    /// Preconditions: none.
    /// Postconditions: returns a valid DateTime for "now".
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Current time used by the system.
        /// Preconditions: none.
        /// Postconditions: returns a valid DateTime.
        /// </summary>
        DateTime Now { get; }
    }
}