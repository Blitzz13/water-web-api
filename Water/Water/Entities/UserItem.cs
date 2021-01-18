namespace Water.Entities
{
	/// <summary>
	/// Represents authentication request
	/// </summary>
	public class UserItem
	{

		/// <summary>
		/// Gets or sets user id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets username
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets user role
		/// </summary>
		public UserRole Role { get; set; }

		/// <summary>
		/// Gets or sets full name
		/// </summary>
		public string FullName { get; set; }
	}
}
