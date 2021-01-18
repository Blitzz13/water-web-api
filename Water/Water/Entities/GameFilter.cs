namespace Water.Entities
{
	/// <summary>
	/// Represents game filter
	/// </summary>
	public class GameFilter
	{
		/// <summary>
		/// Gets or sets id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets is featured
		/// </summary>
		public bool isFeatured { get; set; }

		/// <summary>
		/// Gets or sets genres
		/// </summary>
		public Genre[] Genres { get; set; }

		/// <summary>
		/// Gets or sets states
		/// </summary>
		public GameState[] States { get; set; }
	}
}
