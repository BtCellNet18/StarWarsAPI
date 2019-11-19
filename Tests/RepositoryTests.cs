namespace Tests
{
	using Core.Interfaces;
	using Moq;
	using Xunit;
	public class RepositoryTests
	{
		[Fact]
		public void GetAll_Uses_Correct_URL()
		{
			// Arrage
			string expcted = "https://swapi.co/api/starships/?page=1";
			var mock = new Mock<IDataService>();
			mock.Setup(c => c.GetData(It.IsAny<string>())).Returns(() => null);
			var repository = new Repository(mock.Object);
			// Act
			repository.GetAll();
			// Assert
			mock.Verify(
					d =>
					d.GetData(It.Is<string>(url => url == expcted)),
					Times.Once());
		}

		[Fact]
		public void GetAll_Invalid_Data_Returns_Null()
		{
			// Arrage
			var mock = new Mock<IDataService>();
			mock.Setup(c => c.GetData(It.IsAny<string>())).Returns(string.Empty);
			var repository = new Repository(mock.Object);
			// Act
			var starships = repository.GetAll();
			// Assert
			Assert.Null(starships);
		}

		[Fact]
		public void GetAll_Valid_Data_Returns_Starships()
		{
			// Arrage
			var mock = new Mock<IDataService>();
			mock.Setup(c => c.GetData(It.IsAny<string>())).Returns(this.GetValidData());
			var repository = new Repository(mock.Object);
			// Act
			var starships = repository.GetAll();
			// Assert
			Assert.NotNull(starships);
			Assert.Equal(4, starships.Count);

			foreach (var starship in starships)
			{
				Assert.NotNull(starship.Name);
				Assert.NotNull(starship.Consumables);
				Assert.NotNull(starship.MegaLights);
			}
		}

		private string GetValidData()
		{
			string json = "{'next': null, 'results': [" +
			"{'name': 'Ship 1', 'consumables': '1 year', 'MGLT': '10'}," +
			"{'name': 'Ship 2', 'consumables': '2 months', 'MGLT': '40'}," +
			"{'name': 'Ship 3', 'consumables': '3 weeks', 'MGLT': '80'}," +
			"{'name': 'Ship 4', 'consumables': '4 days', 'MGLT': '120'}" +
			"]}";

			json = json.Replace("'", "\"");

			return json;
		}
	}
}
