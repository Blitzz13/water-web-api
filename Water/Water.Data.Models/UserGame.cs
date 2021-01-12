using System.ComponentModel.DataAnnotations;

namespace Water.Data.Models
{
	public class UserGame
	{
		[Key]
		public string UserId { get; set; }

		[Key]
		public int GameId { get; set; }

		public User User { get; set; }

		public Game Game { get; set; }
	}
}