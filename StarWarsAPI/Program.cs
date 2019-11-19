namespace StarWarsAPI
{
	using Autofac;
	using ConsoleApp;

	class Program
	{
		static void Main(string[] args)
		{
			var container = AutoFaqContainer.Configure();

			using (var scope = container.BeginLifetimeScope())
			{
				var app = scope.Resolve<IApplication>();
				app.Run();
			}
		}
	}
}
