using Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core
{
	/// <summary>
	/// Helper contains results and navigation options.
	/// </summary>
	internal class Helper
	{
		/// <summary>
		/// Gets or sets the results from https://swapi.co/api/starships/.
		/// </summary>
		/// <value>The results.</value>
		[JsonProperty]
		public ICollection<Starship> Results { get; set; }

		/// <summary>
		/// Gets or sets the next page.
		/// </summary>
		/// <value>The next page.</value>
		[JsonProperty]
		public string Next { get; set; }
	}
}
