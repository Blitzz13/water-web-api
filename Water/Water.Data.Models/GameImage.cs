using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Data.Models
{
	public class GameImage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		public string Url { get; set; }

		[Required]
		public int GameId { get; set; }

		[Required]
		public Game Game { get; set; }
	}
}
