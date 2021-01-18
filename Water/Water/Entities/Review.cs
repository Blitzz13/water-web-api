namespace Water.Entities
{
	/// <summary>
	/// Represents review
	/// </summary>
	public class Review
	{
		/// <summary>
		/// Gets or sets id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets content
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets user id
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Gets or sets username
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets upvotes
		/// </summary>
		public int Upvotes { get; set; }
	}
}
