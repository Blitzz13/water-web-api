using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Entities
{
	public class BuyGameRequest
	{
		public string userId { get; set; }

		public string gameId { get; set; }
	}
}
