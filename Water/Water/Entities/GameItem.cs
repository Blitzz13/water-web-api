namespace Water.Entities
{
	/// <summary>
	/// Represents game item
	/// </summary>
	public class GameItem
	{
		/// <summary>
		/// Gets or sets id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets price
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Gets or sets rating
		/// </summary>
		public float Rating { get; set; }

		/// <summary>
		/// Gets or sets cover image
		/// </summary>
		public string CoverImage { get; set; }

		/// <summary>
		/// Gets or sets is featured
		/// </summary>
		public bool IsFeatured { get; set; }
	}
}
