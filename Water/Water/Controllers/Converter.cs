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

		public static Services.Game ConvertAddGameRequestToService(Entities.AddGameRequest value)
		{
			return new Services.Game
			{
				CompanyName = value.CompanyName,
				CoverImage = value.CoverImage,
				Description = value.Description,
				Genre = ConvertGenreToService(value.Genre),
				State = ConvertGameStateToService(value.State),
				ImageUrls = value.ImageUrls,
				IsFeatured = value.IsFeatured,
				Price = value.Price,
			};
		}

		public static Services.GameState ConvertGameStateToService(Entities.GameState value)
		{
			switch (value)
			{
				case Entities.GameState.Released:
					return Services.GameState.Released;
				case Entities.GameState.EarlyAccess:
					return Services.GameState.EarlyAccess;
				case Entities.GameState.Preorder:
					return Services.GameState.Preorder;
				default:
					throw new Exception($"Genre '{value}' is not supported in the current context");
			}
		}

		public static Services.Genre ConvertGenreToService(Entities.Genre value)
		{
			switch (value)
			{
				case Entities.Genre.Cooperative:
					return Services.Genre.Cooperative;
				case Entities.Genre.Action:
					return Services.Genre.Action;
				case Entities.Genre.ActionAdventure:
					return Services.Genre.ActionAdventure;
				case Entities.Genre.Adventure:
					return Services.Genre.Adventure;
				case Entities.Genre.Rpg:
					return Services.Genre.Rpg;
				case Entities.Genre.Simulation:
					return Services.Genre.Simulation;
				case Entities.Genre.Strategy:
					return Services.Genre.Strategy;
				case Entities.Genre.Sport:
					return Services.Genre.Sport;
				default:
					throw new Exception($"Genre '{value}' is not supported in the current context");
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

		public static Entities.Game ConvertGameToEntity(Services.Game value)
		{
			return new Entities.Game
			{
				Id = value.Id,
				CompanyName = value.CompanyName,
				CoverImage = value.CoverImage,
				Description = value.Description,
				Genre = ConvertGenreToEntity(value.Genre),
				State = ConvertGameStateToEntity(value.State),
				ImageUrls = value.ImageUrls,
				IsFeatured = value.IsFeatured,
				Price = value.Price,
			};
		}

		public static Entities.GameState ConvertGameStateToEntity(Services.GameState value)
		{
			switch (value)
			{
				case Services.GameState.Released:
					return Entities.GameState.Released;
				case Services.GameState.EarlyAccess:
					return Entities.GameState.EarlyAccess;
				case Services.GameState.Preorder:
					return Entities.GameState.Preorder;
				default:
					throw new Exception($"Genre '{value}' is not supported in the current context");
			}
		}

		public static Entities.Genre ConvertGenreToEntity(Services.Genre value)
		{
			switch (value)
			{
				case Services.Genre.Cooperative:
					return Entities.Genre.Cooperative;
				case Services.Genre.Action:
					return Entities.Genre.Action;
				case Services.Genre.ActionAdventure:
					return Entities.Genre.ActionAdventure;
				case Services.Genre.Adventure:
					return Entities.Genre.Adventure;
				case Services.Genre.Rpg:
					return Entities.Genre.Rpg;
				case Services.Genre.Simulation:
					return Entities.Genre.Simulation;
				case Services.Genre.Strategy:
					return Entities.Genre.Strategy;
				case Services.Genre.Sport:
					return Entities.Genre.Sport;
				default:
					throw new Exception($"Genre '{value}' is not supported in the current context");
			}
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

		#endregion
	}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
