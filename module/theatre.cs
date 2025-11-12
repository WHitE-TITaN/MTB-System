using System;

namespace MTBSystem.module
{
    public class theatre
    {
        public int TheatreID { get; private set; }
        public int NumberofSeats { get; private set; }
        public string TheatreName { get; private set; }


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