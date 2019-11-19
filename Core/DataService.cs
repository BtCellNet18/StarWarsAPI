namespace Core
{
	using Core.Interfaces;
	using System.IO;
	using System.Net;

	public class DataService : IDataService
	{
		/// <summary>
		/// The web helper
		/// </summary>
		private IWebHelper webHelper;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="webHelper">The web helper.</param>
		public DataService(IWebHelper webHelper)
		{
			this.webHelper = webHelper;
		}

		/// <summary>
		/// Gets data from response.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns>String or null if there are errors processing the request.</returns>
		public string GetData(string url)
		{
			WebRequest request = this.webHelper.GetRequest(url);

			try
			{
				string json = string.Empty;
				WebResponse response = this.webHelper.GetResponse(request);

				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					json = reader.ReadToEnd();
				}

				return json;
			}
			catch (WebException)
			{
				return null;
			}
		}
	}
}
