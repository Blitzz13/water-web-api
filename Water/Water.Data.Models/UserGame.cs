using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Water.Data.Models
{
	public class UserGame
	{
		[Key]
		public string UserId { get; set; }
		
		[Key]
		public string GameId { get; set; }
		
		public User User { get; set; }
		
		public Game Game { get; set; }
	}
}
