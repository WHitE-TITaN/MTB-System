using System;
using MTBSystem.module;

namespace Main
{
    class Program
    {
        static void Main()
        {
            movie l1 = new movie("levithan", "Kratos", "Action", "English");
            l1.displayMovie();

            theatre newTheatre = new theatre(191, 140, "tagorHopuse");
            newTheatre.displayTheatreDetails();

            Customer c1 = new Customer(101, "Ritik", "Delhi");
            c1.displayCustomerDetails();
        }
    }
}