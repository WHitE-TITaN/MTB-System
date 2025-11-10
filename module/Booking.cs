using System;

namespace MTBSystem.module
{
    public class Booking
    {
        public int BookingID { get; private set; }
        public int CustomerID { get; private set; } // Links to Customer.CustomerID
        public int ShowID { get; private set; } // Links to Show.ShowID
        public int NumberOfTickets { get; private set; }
        public DateTime BookingTime { get; private set; }

        public Booking(int bookingID, int customerID, int showID, int numberOfTickets)
        {
            this.BookingID = bookingID;
            this.CustomerID = customerID;
            this.ShowID = showID;
            this.NumberOfTickets = numberOfTickets;
            this.BookingTime = DateTime.Now; // Record booking time automatically
        }
    }
}