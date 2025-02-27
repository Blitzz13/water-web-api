﻿namespace Water.Services
{
	public class User
	{
		public string Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public UserRole Role { get; set; }

		public string FullName { get; set; }
	}
}
