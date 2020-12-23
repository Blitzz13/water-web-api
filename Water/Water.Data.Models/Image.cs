using System.ComponentModel.DataAnnotations;

namespace Water.Data.Models
{
	public class Image
	{
		[Key]
		public string Id { get; set; }

		public byte[] data { get; set; }
	}
}
