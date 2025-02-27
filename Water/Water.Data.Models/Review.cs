﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water.Data.Models
{
	public class Review
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public string UserId { get; set; }

		[Required]
		public User User { get; set; }

		public int Upvotes { get; set; }
	}
}
