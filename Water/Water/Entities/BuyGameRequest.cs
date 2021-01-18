using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Entities
{
	/// <summary>
	/// Represents buy game request
	/// </summary>
	public class BuyGameRequest
	{
		/// <summary>
		/// Gets or sets user id
		/// </summary>
		public string userId { get; set; }

		/// <summary>
		/// Gets or sets game id
		/// </summary>
		public string gameId { get; set; }
	}
}
