namespace Core.Interfaces
{
	using Core.Entities;
	using System.Collections.Generic;

	/// <summary>
	/// IRepository interface
	/// </summary>
	public interface IRepository
	{
		/// <summary>
		/// Gets <see cref="Starship" /> data.
		/// </summary>
		/// <returns>ICollection  <see cref="Starship" />.</returns>
		ICollection<Starship> GetAll();
	}
}
