namespace Tests
{
	using Core;
	using Moq;
	using System.IO;
	using System.Net;
	using Xunit;

	public class WebHelperTests
	{
		[Fact]
		public void GetRequest_Returns_Correct_URL()
		{
			// Arrage
			string expected = "http://www.google.com/";
			// Act
			WebRequest request = new WebHelper().GetRequest(expected);
			// Assert
			Assert.Equal(expected, request.RequestUri.ToString());
		}

		[Fact]
		public void GetResponse_Returns_Expected_String()
		{
			// Arrage
			string expected = "Testing";
			var mock = new Mock<WebRequest>();
			mock.Setup(r => r.GetResponse()).Returns(new MockWebResponse(expected));
			// Act
			WebResponse response = new WebHelper().GetResponse(mock.Object);
			// Assert
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				Assert.Equal(expected, reader.ReadToEnd());
			}
		}
	}
}
