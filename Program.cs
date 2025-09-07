using System;
using MTBSystem.module;

namespace Main
{
    class Program
    {
        static void Main()
        {
            movie l1 = new movie("levithan", "Kratos", "Action", "English");
            Console.WriteLine("completed");

            theatre newTheatre = new theatre(191, 140, "tagorHopuse");
            newTheatre.displayTheatreDetails();
        }
    }
}