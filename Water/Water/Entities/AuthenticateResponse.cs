namespace Water.Entities
{
	/// <summary>
	/// Representes authentication response
	/// </summary>
	public class AuthenticateResponse
	{
		/// <summary>
		/// Gets or sets id
		/// </summary>
		public string Id { get; set; }
		
		/// <summary>
		/// Gets or sets full name
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Gets or sets username
		/// </summary>
		public string Username { get; set; }
		
		/// <summary>
		/// Gets or sets Token
		/// </summary>
		public TokenProvider TokenProvider { get; set; }
	}
}
