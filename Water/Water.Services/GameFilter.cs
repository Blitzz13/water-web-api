namespace Water.Services
{
	public class GameFilter
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public bool isFeatured { get; set; }

		public Genre[] Genres { get; set; }

		public GameState[] States { get; set; }
	}
}
