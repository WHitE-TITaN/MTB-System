using System;

namespace MTBSystem.module
{
    public class loginDetails
    {
        public string LoginID { get; private set; }
        public string Password { get; private set; }
        public string LoginType { get; private set; }
        public int? CustomerId { get; private set; } // Link to Customer.CustomerID (nullable for admin)

        // Constructor for loginDetails
        public loginDetails(string loginID, string password, string loginType, int? customerId)
        {
            this.LoginID = loginID;
            this.Password = password;
            this.LoginType = loginType;
            this.CustomerId = customerId;
        }
    }
}