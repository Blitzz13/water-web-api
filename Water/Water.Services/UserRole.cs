using System.Text.Json.Serialization;

namespace Water.Services
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum UserRole
	{
		Administrator,
		User,
		Company,
	}
}
