namespace Tests
{
	using Core.Entities;
	using System;
	using Xunit;

	public class StarshipTests
	{
		private int distance = 1000000;
		private string unknown = "unknown";

		[Fact]
		public void GetStops_Unknown_Consumables()
		{
			// Arrage
			var starship = new Starship()
			{
				Consumables = unknown,
				MegaLights = "100"
			};
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(unknown, actual);
		}

		[Fact]
		public void GetStops_Unknown_Megalights()
		{
			// Arrage
			var starship = new Starship()
			{
				Consumables = "3 months",
				MegaLights = unknown
			};
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(unknown, actual);
		}

		[Fact]
		public void GetStops_Unknown_Consumables_And_Megalight()
		{
			// Arrage
			var starship = new Starship()
			{
				Consumables = unknown,
				MegaLights = unknown
			};
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(unknown, actual);
		}

		[Fact]
		public void GetStops_Valid_Days()
		{
			// Arrage
			int days = 5;
			int megalights = 120;

			var starship = new Starship()
			{
				Consumables = days.ToString() + " days",
				MegaLights = megalights.ToString()
			};

			DateTime startDate = DateTime.UtcNow;
			DateTime endDate = startDate.AddDays(days);
			double distanceBetweenStops = (endDate - startDate).TotalHours * megalights;
			string expected = Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero).ToString();
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetStops_Valid_Weeks()
		{
			// Arrage
			int weeks = 3;
			int megalights = 80;

			var starship = new Starship()
			{
				Consumables = weeks.ToString() + " weeks",
				MegaLights = megalights.ToString()
			};

			DateTime startDate = DateTime.UtcNow;
			DateTime endDate = startDate.AddDays(weeks * 7);
			double distanceBetweenStops = (endDate - startDate).TotalHours * megalights;
			string expected = Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero).ToString();
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetStops_Valid_Months()
		{
			// Arrage
			int months = 2;
			int megalights = 40;

			var starship = new Starship()
			{
				Consumables = months.ToString() + " months",
				MegaLights = megalights.ToString()
			};

			DateTime startDate = DateTime.UtcNow;
			DateTime endDate = startDate.AddMonths(months);
			double distanceBetweenStops = (endDate - startDate).TotalHours * megalights;
			string expected = Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero).ToString();
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetStops_Valid_Years()
		{
			// Arrage
			int years = 1;
			int megalights = 10;

			var starship = new Starship()
			{
				Consumables = years.ToString() + " year",
				MegaLights = megalights.ToString()
			};

			DateTime startDate = DateTime.UtcNow;
			DateTime endDate = startDate.AddYears(years);
			double distanceBetweenStops = (endDate - startDate).TotalHours * megalights;
			string expected = Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero).ToString();
			// Act
			string actual = starship.GetStops(distance);
			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
