namespace Tests
{
	using System.IO;
	using System.Net;
	using System.Text;

	public class MockWebResponse : WebResponse
	{
		private readonly string content;

		public MockWebResponse(string content)
		{
			this.content = content;
		}

		public override Stream GetResponseStream()
		{
			var bytes = Encoding.UTF8.GetBytes(this.content);
			return new MemoryStream(bytes);
		}
	}
}
