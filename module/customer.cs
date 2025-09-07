using System;

//main module namespace
//constains all then classes of the module;
namespace MTBSystem.module
{
	public class Customer
	{
        /*1. CustomerID as int  
		2. CustomerName as string  
		3. City as string*/

        int CustomerID;
		string CustomerName,
			City;

		//custructor
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