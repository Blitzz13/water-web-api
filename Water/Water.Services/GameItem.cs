namespace Water.Services
{
	public class GameItem
	{
		public string Id { get; set; }
		
		public decimal Price { get; set; }

		public float Rating { get; set; }

		public string CoverImage { get; set; }

		public bool IsFeatured { get; set; }
	}
}
