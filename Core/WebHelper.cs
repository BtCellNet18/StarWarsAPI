namespace Core
{
	using Core.Interfaces;
	using System.Net;

	/// <summary>
	/// Web Helper gets web request and response.
	/// </summary>
	/// <seealso cref="StarWarsApiCSharp.IWebHelper" />
	public class WebHelper : IWebHelper
	{
		/// <summary>
		/// Gets <see cref="WebRequest" />.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns>
		/// <see cref="WebRequest" />.
		/// </returns>
		public virtual WebRequest GetRequest(string url)
		{
			return WebRequest.Create(url);
		}

		/// <summary>
		/// Gets <see cref="WebResponse" />.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>
		/// <see cref="WebResponse" />.
		/// </returns>
		public virtual WebResponse GetResponse(WebRequest request)
		{
			return request.GetResponse();
		}
	}
}
