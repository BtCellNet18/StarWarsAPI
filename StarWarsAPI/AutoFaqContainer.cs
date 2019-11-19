namespace ConsoleApp
{
	using Autofac;
	using Core;
	using Core.Interfaces;

	public static class AutoFaqContainer
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<Application>().As<IApplication>();
			builder.RegisterType<WebHelper>().As<IWebHelper>();
			builder.RegisterType<DataService>().As<IDataService>();
			builder.RegisterType<Repository>().As<IRepository>();

			return builder.Build();
		}
	}
}
