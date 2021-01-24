using System.Collections.Generic;

namespace Water.Entities
{
	/// <summary>
	/// Represents add game request
	/// </summary>
	public class UpdateGameRequest
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
		/// Gets or sets description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets price
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Gets or sets rating
		/// </summary>
		public float Rating { get; set; }

		/// <summary>
		/// Gets or sets state
		/// </summary>
		public GameState State { get; set; }

		/// <summary>
		/// Gets or sets cover image
		/// </summary>
		public string CoverImage { get; set; }

		/// <summary>
		/// Gets or sets image urls
		/// </summary>
		public List<string> ImageUrls { get; set; }
		
		/// <summary>
		/// Gets or sets genre
		/// </summary>
		public Genre Genre { get; set; }

		/// <summary>
		/// Gets or sets is featured
		/// </summary>
		public bool IsFeatured { get; set; }

		/// <summary>
		/// Gets or sets compamy name
		/// </summary>
		public string CompanyName { get; set; }
	}
}
