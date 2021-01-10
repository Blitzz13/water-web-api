using System.ComponentModel.DataAnnotations;

namespace Water.Services
{
	public class UserAuthenticateRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
