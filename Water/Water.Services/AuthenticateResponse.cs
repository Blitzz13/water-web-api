namespace Water.Services
{
	public class AuthenticateResponse
	{
		public string Id { get; set; }
		
		public string FullName { get; set; }
		
		public string Username { get; set; }

		public UserRole Role { get; set; }

		public TokenProvider TokenProvider { get; set; }
	}
}
