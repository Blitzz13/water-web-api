namespace Water.Entities
{
	public class Review
	{
		public string Id { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public string Username { get; set; }

		public int Upvotes { get; set; }
	}
}
