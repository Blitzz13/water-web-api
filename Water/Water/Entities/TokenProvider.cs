namespace Water.Entities
{
	/// <summary>
	/// Represents token provider
	/// </summary>
	public class TokenProvider
	{
		/// <summary>
		/// Gets or sets token
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// Gets or sets token expiration in seconds
		/// </summary>
		public long ExpiresInSeconds { get; set; }
	}
}
