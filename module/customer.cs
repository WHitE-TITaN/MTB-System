using System;

namespace MTBSystem.module
{
    public class Customer
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; private set; }
        public string City { get; private set; }

        //constructor
        public Customer(int CustomerID, string CustomberName, string City)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomberName;
            this.City = City;
        }

        //display customer details
        public void displayCustomerDetails()
        {
            Console.WriteLine($"\nCustomer Details -\n" +
                $"ID - {this.CustomerID}\n" +
                $"Name - {this.CustomerName}\n" +
                $"City - {this.City}\n");
        }
    }
}