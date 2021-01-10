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
				Username = value.Username,
				Password = value.Password,
				Email = value.Email,
				FullName = value.FullName,
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
					throw new Exception($"User role '{value}' is not supported in the current context");
			}
		}

		public static Services.UserAuthenticateRequest ConvertAuthenticateRequestToService(Entities.AuthenticateRequest value)
		{
			return new Services.UserAuthenticateRequest
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
				Id = value.Id,
				Username = value.Username,
				UserRole = ConvertUserRoleToEntity(value.Role),
				TokenProvider = ConvertTokenProviderToEntity(value.TokenProvider),
			};
		}

		public static Entities.TokenProvider ConvertTokenProviderToEntity(Services.TokenProvider value)
		{
			return new Entities.TokenProvider
			{
				Token = value.Token,
				ExpiresInSeconds = value.ExpiresInSeconds,
			};
		}

		public static Entities.UserRole ConvertUserRoleToEntity(Services.UserRole value)
		{
			switch (value)
			{
				case Services.UserRole.Administrator:
					return Entities.UserRole.Administrator;
				case Services.UserRole.User:
					return Entities.UserRole.User;
				case Services.UserRole.Company:
					return Entities.UserRole.Company;
				default:
					throw new Exception($"User role '{value}' is not supported in the current context");
			}
		}

		public static Entities.User ConvertUserToEntity(Services.User value)
		{
			return new Entities.User
			{
				Username = value.Username,
				Password = value.Password,
				Email = value.Email,
				FullName = value.FullName,
				Role = ConvertUserRoleToEntity(value.Role),
			};
		}
		#endregion
	}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
