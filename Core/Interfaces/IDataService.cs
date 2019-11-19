namespace Core.Interfaces
{
	/// <summary>
	/// IDataService Interface. 
	/// </summary>
	public interface IDataService
	{
		/// <summary>
		/// Gets JSON data as string. Assumes syntax and format are valid. 
		/// </summary>
		/// <param name="url">The URL to consume.</param>
		/// <returns>JSON data as string.</returns>
		string GetData(string url);
	}
}
