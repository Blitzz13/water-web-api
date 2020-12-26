using System.Text.Json.Serialization;

namespace Water.Entities
{
	/// <summary>
	/// Representes enumeration user roles
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum UserRole
	{
		/// <summary>
		/// Administrator
		/// </summary>
		Administrator,
		/// <summary>
		/// User
		/// </summary>
		User,
		/// <summary>
		/// Company
		/// </summary>
		Company,
	}
}
