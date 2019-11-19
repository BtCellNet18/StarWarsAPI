namespace ConsoleApp
{
	using Core.Interfaces;
	using System;

	public class Application : IApplication
	{
		private IRepository repository;

		public Application(IRepository repository)
		{
			this.repository = repository;
		}

		public void Run()
		{
			int distance;
			string inputMessage = "Enter distance in mega lights: ";

			Console.Write(inputMessage);

			while (!int.TryParse(Console.ReadLine(), out distance) || distance < 1)
			{
				Console.WriteLine("Invalid distance must be an integer value greater than 0.");
				Console.Write(inputMessage);
			}

			Console.WriteLine("");
			Console.WriteLine("Getting star ship data...");
			Console.WriteLine("");

			var starships = repository.GetAll();

			if (starships == null)
			{
				Console.WriteLine("Failed to get star ship data");
				Console.WriteLine("Please check data connection");
			}
			else
			{
				foreach (var starship in starships)
				{
					Console.WriteLine($"{starship.Name}: {starship.GetStops(distance)}");
				}
			}

			Console.WriteLine("");
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}
	}
}
