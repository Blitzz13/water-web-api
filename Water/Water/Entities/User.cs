﻿using System.Text.Json.Serialization;

namespace Water.Entities
{
	/// <summary>
	/// Representes user
	/// </summary>
	public class User
	{
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

		/// <summary>
		/// Gets or sets password
		/// </summary>
		[JsonIgnore]
		public string Password { get; set; }
	}
}
