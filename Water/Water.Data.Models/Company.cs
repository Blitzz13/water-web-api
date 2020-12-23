using System.ComponentModel.DataAnnotations;

namespace Water.Data.Models
{
	public class Company
	{
		[Key]
		[Required]
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		public Game[] CreatedGames { get; set; }
	}
}
