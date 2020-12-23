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

		public UserGame[] UserGame { get; set; }

		public UserRole Role { get; set; }

		public Image ProfilePicture { get; set; }
		
		public Review[] Reviews { get; set; }

		public string FullName { get; set; }
	}
}
