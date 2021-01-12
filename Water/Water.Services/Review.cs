using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Services
{
	public class Review
	{
		public string Id { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public int Upvotes { get; set; }
	}
}
