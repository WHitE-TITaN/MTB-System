using System;

namespace MTBSystem.module
{
    public class Show
    {
        public int ShowID { get; private set; }
        public string MovieID { get; private set; } // Links to movie.MovieID
        public int TheatreID { get; private set; } // Links to theatre.TheatreID
        public DateTime ShowTime { get; private set; }
        public int AvailableSeats { get; set; } // Use 'set' to update when booking

        public Show(int showID, string movieID, int theatreID, DateTime showTime, int totalSeats)
        {
            this.ShowID = showID;
            this.MovieID = movieID;
            this.TheatreID = theatreID;
            this.ShowTime = showTime;
            this.AvailableSeats = totalSeats;
        }
    }
}