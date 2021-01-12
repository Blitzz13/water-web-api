using System.Collections.Generic;

namespace Water.Entities
{
	public class Game
	{
		public string Id { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public float Rating { get; set; }

		public List<Review> Reviews { get; set; }

		public GameState State { get; set; }

		public string CoverImage { get; set; }

		public List<string> ImageUrls { get; set; }

		public Genre Genre { get; set; }

		public bool IsFeatured { get; set; }

		public string CompanyName { get; set; }
	}
}
