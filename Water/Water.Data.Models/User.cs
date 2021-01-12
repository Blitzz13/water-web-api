using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Data.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();

		public UserRole Role { get; set; }

		public string ProfilePicture { get; set; }

		public ICollection<Review> Reviews { get; set; } = new List<Review>();

		public string FullName { get; set; }
	}
}
