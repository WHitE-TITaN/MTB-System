using System;

//main module namespace
//constains all then classes of the module;
namespace MTBSystem.module
{
	/*1. TheatreID as int  
	  2. ThreatreName as string  
	  3. NumberofSeats as int*/
    public class theatre
	{
		int TheatreID,
			NumberofSeats;
		string TheatreName;


		//main constructor for theatre.
		public theatre(int TheatreID, int numberofSeats, string TheatreName)
		{
			this.TheatreID = TheatreID;
			this.TheatreName = TheatreName;
			this.NumberofSeats = numberofSeats;
		}

		//show the details of the theatre;
		public void displayTheatreDetails()
		{
			Console.WriteLine($"\nTheatre Details -\n" +
				$"ID - {this.TheatreID}\n" +
				$"Name - {this.TheatreName}\n" +
				$"Number of seats - {this.NumberofSeats}\n");
		}
	}
}



