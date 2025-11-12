using System;
using System.Linq;
using MTBSystem.module;
using MTBSystem.module.exception;

namespace Main
{
    class Program
    {
        static loginDetails? loggedInUser = null;

        static void Main()
        {
            // Load initial data (test accounts, sample movies, etc.)
            SeedData();

            Console.WriteLine("=========================================");
            Console.WriteLine(" Welcome to the Movie Ticket Booking System");
            Console.WriteLine("=========================================");

            while (true)
            {
                if (loggedInUser == null)
                {
                    HandleLogin();
                }
                else
                {
                    if (loggedInUser.LoginType == "Admin")
                    {
                        AdminMenu();
                    }
                    else if (loggedInUser.LoginType == "Customer")
                    {
                        CustomerMenu();
                    }
                }
            }
        }

        static void SeedData()
        {
            // Add test accounts
            // 1. Admin Account
            DataStore.Logins.Add(new loginDetails("admin", "admin", "Admin", null));

            // 2. Customer Account
            int testCustomerId = DataStore.GetNextCustomerId(); // Gets 101
            DataStore.Customers.Add(new Customer(testCustomerId, "Test User", "Test City"));
            DataStore.Logins.Add(new loginDetails("hello", "0816", "Customer", testCustomerId));

            // Add sample data
            try
            {
                DataStore.Movies.Add(new movie("Inception", "Nolan", "Sci-Fi", "English"));
                DataStore.Movies.Add(new movie("Dangal", "Aamir Khan", "Drama", "Hindi"));
            }
            catch (LanguageException ex) { Console.WriteLine(ex.Message); }

            DataStore.Theatres.Add(new theatre(1, 100, "PVR Cinemas"));
            DataStore.Theatres.Add(new theatre(2, 80, "Cineplex"));
        }

        static void HandleLogin()
        {
            Console.WriteLine("\n--- LOGIN ---");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter Password: ");
            string password = Console.ReadLine() ?? "";

            // Find user in the data store
            loggedInUser = DataStore.Logins.FirstOrDefault(user =>
                user.LoginID.Equals(username) && user.Password.Equals(password));

            if (loggedInUser != null)
            {
                Console.WriteLine($"\nLogin Successful! Welcome, {username} ({loggedInUser.LoginType}).");
            }
            else
            {
                Console.WriteLine("\nInvalid username or password. Please try again.");
            }
        }

        static void Logout()
        {
            loggedInUser = null;
            Console.WriteLine("\nYou have been logged out.");
        }

        #region Admin Menu
        static void AdminMenu()
        {
            while (loggedInUser != null)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add New Movie");
                Console.WriteLine("2. Add New Theatre");
                Console.WriteLine("3. Add New Show");
                Console.WriteLine("4. View All Bookings");
                Console.WriteLine("5. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewMovie();
                        break;
                    case "2":
                        AddNewTheatre();
                        break;
                    case "3":
                        AddNewShow();
                        break;
                    case "4":
                        ViewAllBookings();
                        break;
                    case "5":
                        Logout();
                        return; // Exit admin loop
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddNewMovie()
        {
            try
            {
                Console.Write("Enter Movie Name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Enter Producer Name: ");
                string producer = Console.ReadLine() ?? "";
                Console.Write("Enter Genre: ");
                string genre = Console.ReadLine() ?? "";
                Console.Write("Enter Language (English, Hindi, Bhojpuri, Marathi): ");
                string lang = Console.ReadLine() ?? "";

                movie newMovie = new movie(name, producer, genre, lang);
                DataStore.Movies.Add(newMovie);
                newMovie.displayMovie();
            }
            catch (LanguageException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AddNewTheatre()
        {
            try
            {
                Console.Write("Enter Theatre ID (number): ");
                int id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter Theatre Name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Enter Number of Seats: ");
                int seats = int.Parse(Console.ReadLine() ?? "0");

                theatre newTheatre = new theatre(id, seats, name);
                DataStore.Theatres.Add(newTheatre);
                newTheatre.displayTheatreDetails();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number for ID and seats.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AddNewShow()
        {
            try
            {
                Console.WriteLine("\n--- Available Movies ---");
                foreach (var m in DataStore.Movies)
                {
                    Console.WriteLine($"ID: {m.MovieID} | Name: {m.MovieName}");
                }
                Console.Write("Enter Movie ID to schedule: ");
                string movieId = Console.ReadLine() ?? "";
                var movie = DataStore.Movies.FirstOrDefault(m => m.MovieID.Equals(movieId, StringComparison.OrdinalIgnoreCase));
                if (movie == null)
                {
                    Console.WriteLine("Movie not found.");
                    return;
                }

                Console.WriteLine("\n--- Available Theatres ---");
                foreach (var t in DataStore.Theatres)
                {
                    Console.WriteLine($"ID: {t.TheatreID} | Name: {t.TheatreName} | Seats: {t.NumberofSeats}");
                }
                Console.Write("Enter Theatre ID: ");
                int theatreId = int.Parse(Console.ReadLine() ?? "0");
                var theatre = DataStore.Theatres.FirstOrDefault(t => t.TheatreID == theatreId);
                if (theatre == null)
                {
                    Console.WriteLine("Theatre not found.");
                    return;
                }

                Console.Write("Enter Show Time (e.g., 2025-12-25 18:30): ");
                DateTime showTime = DateTime.Parse(Console.ReadLine() ?? "");

                int showId = DataStore.GetNextShowId();
                Show newShow = new Show(showId, movie.MovieID, theatre.TheatreID, showTime, theatre.NumberofSeats);
                DataStore.Shows.Add(newShow);

                Console.WriteLine($"\nSuccess! Show created (ID: {showId}) for '{movie.MovieName}' at '{theatre.TheatreName}' on {showTime}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating show: {ex.Message}");
            }
        }

        static void ViewAllBookings()
        {
            Console.WriteLine("\n--- All Bookings (Admin View) ---");
            if (!DataStore.Bookings.Any())
            {
                Console.WriteLine("No bookings have been made yet.");
                return;
            }

            foreach (var booking in DataStore.Bookings)
            {
                var show = DataStore.Shows.FirstOrDefault(s => s.ShowID == booking.ShowID);
                var customer = DataStore.Customers.FirstOrDefault(c => c.CustomerID == booking.CustomerID);
                if (show != null && customer != null)
                {
                    var movie = DataStore.Movies.FirstOrDefault(m => m.MovieID == show.MovieID);
                    Console.WriteLine($"Booking ID: {booking.BookingID} | Customer: {customer.CustomerName} (ID: {customer.CustomerID}) | Movie: {movie?.MovieName} | Tickets: {booking.NumberOfTickets} | Booked On: {booking.BookingTime.ToShortDateString()}");
                }
            }
        }
        #endregion

        #region Customer Menu
        static void CustomerMenu()
        {
            while (loggedInUser != null)
            {
                Console.WriteLine("\n--- Customer Menu ---");
                Console.WriteLine("1. View Available Shows");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. View My Bookings");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewAvailableShows();
                        break;
                    case "2":
                        BookTicket();
                        break;
                    case "3":
                        ViewMyBookings();
                        break;
                    case "4":
                        Logout();
                        return; // Exit customer loop
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ViewAvailableShows()
        {
            Console.WriteLine("\n--- Available Shows ---");
            if (!DataStore.Shows.Any())
            {
                Console.WriteLine("Sorry, no shows are currently scheduled.");
                return;
            }

            foreach (var show in DataStore.Shows)
            {
                var movie = DataStore.Movies.FirstOrDefault(m => m.MovieID == show.MovieID);
                var theatre = DataStore.Theatres.FirstOrDefault(t => t.TheatreID == show.TheatreID);
                if (movie != null && theatre != null)
                {
                    Console.WriteLine($"Show ID: {show.ShowID} | Movie: {movie.MovieName} ({movie.Language}) | Theatre: {theatre.TheatreName} | Time: {show.ShowTime} | Seats Available: {show.AvailableSeats}");
                }
            }
        }

        static void BookTicket()
        {
            ViewAvailableShows();
            if (!DataStore.Shows.Any()) return;

            try
            {
                Console.Write("\nEnter the Show ID you want to book: ");
                int showId = int.Parse(Console.ReadLine() ?? "0");

                var show = DataStore.Shows.FirstOrDefault(s => s.ShowID == showId);
                if (show == null)
                {
                    Console.WriteLine("Show ID not found.");
                    return;
                }

                Console.Write($"Enter number of tickets (Available: {show.AvailableSeats}): ");
                int numTickets = int.Parse(Console.ReadLine() ?? "0");

                if (numTickets <= 0)
                {
                    Console.WriteLine("Must book at least 1 ticket.");
                    return;
                }
                if (numTickets > show.AvailableSeats)
                {
                    Console.WriteLine("Not enough available seats.");
                    return;
                }

                // Get current customer ID
                int customerId = loggedInUser!.CustomerId.Value; // We know this is a customer, so CustomerId is not null

                // Create booking
                int bookingId = DataStore.GetNextBookingId();
                Booking newBooking = new Booking(bookingId, customerId, showId, numTickets);
                DataStore.Bookings.Add(newBooking);

                // Update available seats
                show.AvailableSeats -= numTickets;

                Console.WriteLine($"\nSuccess! Your booking is confirmed. Booking ID: {bookingId}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ViewMyBookings()
        {
            int customerId = loggedInUser!.CustomerId.Value;
            var myBookings = DataStore.Bookings.Where(b => b.CustomerID == customerId).ToList();

            Console.WriteLine("\n--- My Bookings ---");
            if (!myBookings.Any())
            {
                Console.WriteLine("You have no bookings.");
                return;
            }

            foreach (var booking in myBookings)
            {
                var show = DataStore.Shows.FirstOrDefault(s => s.ShowID == booking.ShowID);
                if (show != null)
                {
                    var movie = DataStore.Movies.FirstOrDefault(m => m.MovieID == show.MovieID);
                    var theatre = DataStore.Theatres.FirstOrDefault(t => t.TheatreID == show.TheatreID);
                    Console.WriteLine($"Booking ID: {booking.BookingID} | Movie: {movie?.MovieName} | Theatre: {theatre?.TheatreName} | Show Time: {show.ShowTime} | Tickets: {booking.NumberOfTickets}");
                }
            }
        }
        #endregion
    }
}