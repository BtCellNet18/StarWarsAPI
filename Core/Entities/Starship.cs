namespace Core.Entities
{
	using Newtonsoft.Json;
	using System;

	public class Starship
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the mega lights. It can return "unknown" as value.
		/// </summary>
		/// <value>The mega lights.</value>
		[JsonProperty(PropertyName = "MGLT")]
		public string MegaLights { get; set; }

		/// <summary>
		/// Gets or sets the consumables period. It can return "unknown" as value.
		/// </summary>
		/// <value>The consumables.</value>
		[JsonProperty]
		public string Consumables { get; set; }

		/// <summary>
		/// Gets number of stops required to travel a specifed distance in mega lights. 
		/// Can return "unknown" as value.
		/// </summary>
		/// <param name="distance">Distance in mega lights</param>
		/// <value>Number as string or "unknown"</value>
		public string GetStops(int distance)
		{
			string value = "unknown";

			if (this.MegaLights == value
				|| this.Consumables == value)
			{
				return value;
			}

			string[] consumables = this.Consumables.Split(" ");

			int quantity;
			int megalights;

			if (consumables.Length > 1
				&& int.TryParse(consumables[0], out quantity)
				&& int.TryParse(this.MegaLights, out megalights))
			{
				string duration = consumables[1];

				DateTime startDate = DateTime.UtcNow;
				DateTime endDate = startDate;

				if (duration.StartsWith("day"))
				{
					endDate = startDate.AddDays(quantity);
				}

				if (duration.StartsWith("week"))
				{
					endDate = startDate.AddDays(quantity * 7);
				}

				if (duration.StartsWith("month"))
				{
					endDate = startDate.AddMonths(quantity);
				}

				if (duration.StartsWith("year"))
				{
					endDate = startDate.AddYears(quantity);
				}

				if (endDate.Ticks > startDate.Ticks)
				{
					double distanceBetweenStops = (endDate - startDate).TotalHours * megalights;
					value = Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero).ToString();
				}
			}

			return value;
		}
	}
}
