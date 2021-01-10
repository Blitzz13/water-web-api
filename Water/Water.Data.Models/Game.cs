using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Data.Models
{
	public class Game
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public float Rating { get; set; }

		[Required]
		[ForeignKey(nameof(Company))]
		public string CompanyId { get; set; }

		//[Required]
		//public Company Company { get; set; }

		public UserGame UserGame { get; set; }

		[Required]
		public Review[] Reviews { get; set; }

		[Required]
		public GameState State { get; set; }

		[Required]
		public Image[] Images { get; set; }

		[Required]
		public Genre Genres { get; set; }
	}
}
