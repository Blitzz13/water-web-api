namespace Water.Entities
{
	/// <summary>
	/// Authentication response
	/// </summary>
	public class AuthenticateResponse
	{
		/// <summary>
		/// Gets or sets id
		/// </summary>
		public int Id { get; set; }
		
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
		public string Token { get; set; }
	}
}
