using Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
	/// <summary>
	/// Repository stores <see cref="Starship"> data.
	/// </summary>
	public class Repository : IRepository
	{
		/// <summary>
		/// The data service.
		/// </summary>
		private IDataService dataService;

		public Repository(IDataService dataService)
		{
			this.dataService = dataService;
		}

		/// <summary>
		/// Gets all <see cref="Starship" /> data.
		/// </summary>
		/// <returns>ICollection <see cref="Starship" />.</returns>
		public ICollection<Starship> GetAll()
		{
			IEnumerable<Starship> results = new List<Starship>();

			var helper = new Helper()
			{
				Next = "https://swapi.co/api/starships/?page=1"
			};

			while (helper.Next != null)
			{
				string json = this.dataService.GetData(helper.Next);

				if (json == null)
				{
					return null;
				}

				helper = JsonConvert.DeserializeObject<Helper>(json);

				if (helper == null)
				{
					return null;
				}

				results = results.Union(helper.Results);
			}

			return results.ToList();
		}
	}
}
