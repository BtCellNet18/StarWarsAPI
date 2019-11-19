namespace Core.Interfaces
{
	using System.Net;

	/// <summary>
	/// IWeHelper Interface.
	/// </summary>
	public interface IWebHelper
	{
		/// <summary>
		/// Gets <see cref="WebRequest"/>.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns><see cref="WebRequest"/>.</returns>
		WebRequest GetRequest(string url);

		/// <summary>
		/// Gets <see cref="WebResponse"/>.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns><see cref="WebResponse"/>.</returns>
		WebResponse GetResponse(WebRequest request);
	}
}
