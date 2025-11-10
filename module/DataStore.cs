using System.Collections.Generic;
using MTBSystem.module;

namespace MTBSystem.module
{
    public static class DataStore
    {
        // In-memory lists to store all application data
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<movie> Movies { get; set; } = new List<movie>();
        public static List<theatre> Theatres { get; set; } = new List<theatre>();
        public static List<loginDetails> Logins { get; set; } = new List<loginDetails>();
        public static List<Show> Shows { get; set; } = new List<Show>();
        public static List<Booking> Bookings { get; set; } = new List<Booking>();

        // Auto-incrementing IDs for new records
        private static int nextShowId = 1;
        private static int nextBookingId = 1;
        private static int nextCustomerId = 101; // Start customer IDs from 101

        public static int GetNextShowId() => nextShowId++;
        public static int GetNextBookingId() => nextBookingId++;
        public static int GetNextCustomerId() => nextCustomerId++;
    }
}