using System;

namespace Water.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static class Converter

	{
		#region Convert to service
		public static Services.User ConvertUserToService(Entities.User value)
		{
			return new Services.User
			{
				Email = value.Email,
				FullName = value.FullName,
				Username = value.Username,
				Password = value.Password,
				Role = ConvertUserRoleToService(value.Role)
			};
		}

		public static Services.UserRole ConvertUserRoleToService(Entities.UserRole value)
		{
			switch (value)
			{
				case Entities.UserRole.Administrator:
					return Services.UserRole.Administrator;
				case Entities.UserRole.User:
					return Services.UserRole.User;
				case Entities.UserRole.Company:
					return Services.UserRole.Company;
				default:
					throw new Exception($"User role {value} is not supported in the current context");
			}
		}

		public static Services.AuthenticateRequest ConvertAuthenticateRequestToService(Entities.AuthenticateRequest value)
		{
			return new Services.AuthenticateRequest
			{
				Username = value.Username,
				Password = value.Password,
			};
		}
		#endregion

		#region Convert to entities
		public static Entities.AuthenticateResponse ConvertAuthenticateResponseToEntity(Services.AuthenticateResponse value)
		{
			return new Entities.AuthenticateResponse
			{
				Username = value.Username,
				FullName = value.FullName,
				Id = value.Id,
				Token = value.Token,
			};
		}
		#endregion
	}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
