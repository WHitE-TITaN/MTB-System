# Movie Ticket Booking System (Console Mini-Project)

This is a simple, text-based console application for a movie ticket booking system. It is built using .NET 8 and C# and operates entirely in-memory, using static lists instead of an external database.

The project features two distinct user roles:
* **Admin:** Manages movies, theatres, and show schedules.
* **Customer:** Views available shows and books tickets.

## 🚀 Features

### Admin
* Log in as an administrator.
* Add new movies to the system (with language validation).
* Add new theatres with seating capacity.
* Schedule new shows, linking a movie to a theatre at a specific time.
* View a complete list of all bookings made by all customers.

### Customer
* Log in as a customer.
* View a list of all available shows, including movie, theatre, time, and available seats.
* Book one or more tickets for an available show.
* View a personal list of all tickets they have previously booked.

### General
* **No Database Required:** All data is stored in-memory and will reset when the application is closed.
* **Role-Based Menus:** The application shows different menus based on whether an Admin or Customer is logged in.
* **Test Accounts:** Pre-configured accounts for testing both user types.

## 🛠️ Tech Stack & Requirements

* **.NET 8 SDK**
* **C#**
* A terminal or console to run the application.

## 🏁 How to Run

1.  Ensure you have the **.NET 8 SDK** installed on your machine.
2.  Place all the project files (`.csproj`, `Program.cs`, and all files in the `module` folder) into a single directory.
3.  Open a terminal or command prompt and navigate to that directory.
4.  Run the following command:

    ```sh
    dotnet run
    ```

5.  The application will start in your console.

## 🧑‍💻 Usage & Test Accounts

The application will first prompt you for a login. You can use the following pre-configured test accounts to access the system.

| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | `admin` | `admin` |
| **Customer** | `hello` | `0816` |

Once logged in, you can navigate the menus by typing the corresponding number and pressing Enter.

## 📂 Project Structure

MTB-System/
│
├── WindowsFormsApp/
│   ├── Forms/               # Admin dashboard and management windows
│   ├── Models/              # Data models (Movie, Booking, etc.)
│   ├── Program.cs           # Entry point for Windows app
│   └── ...
│
├── WebApp/
│   ├── Pages/               # ASP.NET pages for user interaction
│   ├── Scripts/             # Client-side scripts
│   ├── Styles/              # CSS stylesheets
│   └── ...
│
└── README.md

## 🔮 Future Improvements

This is a mini-project, but its functionality could be extended:
* **Seat Selection:** Implement a visual grid (e.g., 10x10) for users to select specific seats instead of just a quantity.
* **Data Persistence:** Replace the `DataStore` with a persistent solution, such as writing to JSON files or using SQLite.
* **Expanded Details:** Add more properties to movies (like `Duration` or `Story`) and use them in the UI.