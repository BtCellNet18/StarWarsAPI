namespace Tests
{
	using Core;
	using Core.Interfaces;
	using Moq;
	using System.Net;
	using Xunit;

	public class DataServiceTests
	{

		[Fact]
		public void GetData_Returns_Expected_String()
		{
			// Arrage
			string expected = "Testing";
			var mock = new Mock<IWebHelper>();
			mock.Setup(w => w.GetResponse(It.IsAny<WebRequest>())).Returns(new MockWebResponse(expected));
			// Act
			string actual = new DataService(mock.Object).GetData("http://test.com/");
			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetData_Failure_Returns_Null()
		{
			// Arrage
			var mock = new Mock<IWebHelper>();
			mock.Setup(w => w.GetResponse(It.IsAny<WebRequest>())).Throws(new WebException());
			// Act
			string actual = new DataService(mock.Object).GetData("http://test.com/");
			// Assert
			Assert.Null(actual);
		}
	}
}
