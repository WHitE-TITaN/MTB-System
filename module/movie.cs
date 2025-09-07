using System;


//main module namespace
//constains all then classes of the module;
namespace MTBSystem.module
{
    /*1. MovieID as string  
	2. MovieName as string  
	3. DirectorName as string  
	4. ProducerName as string  
	5. Duration as double  
	6. Story as string  
	7. Genre as string  
	8. Language as string */
    public class movie{
		string MovieID,
			MovieName,
			ProducerName,
			story,
			Genre,
			Language;

		double Duration;


		//constructor for movie registration.
		public movie(string MovieName, string ProducerName, string Genre, string Language)
		{
			Console.WriteLine("Generating ID");
			string id = MovieName.Substring(0, 2) + ProducerName.Substring(0, 2) +
				Genre.Substring(0, 2) + Language.Substring(0, 2);

			MovieID = id;
		}

		public void displayMovie()
		{
            Console.WriteLine($"Details are As - \nName - {MovieName}" +
                $"\n Producer - {ProducerName}" +
                $"\n Genre - {Genre}" +
                $"\n ID - {id}");
        }
	}
}