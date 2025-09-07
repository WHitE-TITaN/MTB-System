using System;

//main module namespace
namespace MTBSystem.module
{
    public class loginDetails
    {
        /*1. LoginID as string  
        2. Password as string  
        3. LoginType as string */
        string loginID,
            password,
            loginType;

        //constructor for loginDetails
        //LoginID is same as CustomerID 
        public loginDetails(string customerID)
        {
            //default allocation of loginID and password to customerID
            this.loginID = customerID;
            this.password = customerID;

            //static Allocation of loginType to movieadmin.
            if (customerID != "MOVIEADMIN")
            {
                this.loginType = "Customer";
            }
            else
            {
                this.loginType = "Admin";
            }
        }
    }
}

