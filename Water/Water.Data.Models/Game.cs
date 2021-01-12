using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Data.Models
{
	public class Game
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public float Rating { get; set; }

		//[Required]
		//[ForeignKey(nameof(Company))]
		//public string CompanyId { get; set; }

		//[Required]
		//public Company Company { get; set; }

		[Required]
		public string CompanyName { get; set; }

		public ICollection<Review> Reviews { get; set; } = new List<Review>();

		public ICollection<GameImage> Images { get; set; } = new List<GameImage>();

		public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();

		[Required]
		public GameState State { get; set; }

		[Required]
		public string CoverImage { get; set; }

		[Required]
		public Genre Genre { get; set; }

		[Required]
		public bool IsFeatured { get; set; }
	}
}
