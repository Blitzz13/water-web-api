using System.Text.Json.Serialization;

namespace Water.Entities
{
	public class Company
	{
		public string Name { get; set; }

		public string Email { get; set; }

		[JsonIgnore]
		public string Password { get; set; }
	}
}
