using System.Collections.Generic;
using DATA_MODELS = Water.Data.Models;

namespace Water.Services.Impl.Conversions
{
	public static class Converter
	{
		#region Convert to service
		public static User ConvertUserToService(DATA_MODELS.User value)
		{
			return new User
			{
				Id = value.Id,
				Email = value.Email,
				FullName = value.FullName,
				Password = value.Password,
				Username = value.Username,
				Role = ConvertUserRoleToService(value.Role),
			};
		}
		public static Company ConvertCompanyToService(DATA_MODELS.Company value)
		{
			return new Company
			{
				Email = value.Email,
				Name = value.Name,
			};
		}

		public static Game ConvertGameToService(DATA_MODELS.Game value)
		{
			var images = new List<string>();
			foreach (DATA_MODELS.GameImage image in value.Images)
			{
				images.Add(image.Url);
			}

			return new Game
			{
				Id = value.Id.ToString(),
				CompanyName = value.CompanyName,
				CoverImage = value.CoverImage,
				Description = value.Description,
				Genre = ConvertGenreToService(value.Genre),
				State = ConvertGameStateToService(value.State),
				ImageUrls = images,
				IsFeatured = value.IsFeatured,
				Price = value.Price,
			};
		}

		public static UserRole ConvertUserRoleToService(DATA_MODELS.UserRole value)
		{
			switch (value)
			{
				case DATA_MODELS.UserRole.Administrator:
					return UserRole.Administrator;
				case DATA_MODELS.UserRole.User:
					return UserRole.User;
				default:
					throw new System.Exception($"User role '{value}' is not supported in the current context");
			}
		}
		#endregion

		public static GameState ConvertGameStateToService(DATA_MODELS.GameState value)
		{
			switch (value)
			{
				case DATA_MODELS.GameState.Released:
					return GameState.Released;
				case DATA_MODELS.GameState.EarlyAccess:
					return GameState.EarlyAccess;
				case DATA_MODELS.GameState.Preorder:
					return GameState.Preorder;
				default:
					throw new System.Exception($"Game state '{value}' is not supported in the current context");
			}
		}

		public static Genre ConvertGenreToService(DATA_MODELS.Genre value)
		{
			switch (value)
			{
				case DATA_MODELS.Genre.Cooperative:
					return Genre.Cooperative;
				case DATA_MODELS.Genre.Action:
					return Genre.Action;
				case DATA_MODELS.Genre.ActionAdventure:
					return Genre.ActionAdventure;
				case DATA_MODELS.Genre.Adventure:
					return Genre.Adventure;
				case DATA_MODELS.Genre.Rpg:
					return Genre.Rpg;
				case DATA_MODELS.Genre.Simulation:
					return Genre.Simulation;
				case DATA_MODELS.Genre.Strategy:
					return Genre.Strategy;
				case DATA_MODELS.Genre.Sport:
					return Genre.Sport;
				default:
					throw new System.Exception($"Genre '{value}' is not supported in the current context");
			}
		}

		#region Convert to data
		public static DATA_MODELS.User ConvertUserToData(User value)
		{
			return new DATA_MODELS.User
			{
				Email = value.Email,
				FullName = value.FullName,
				Password = value.Password,
				Username = value.Username,
				Role = ConvertUserRoleToData(value.Role)
			};
		}

		public static DATA_MODELS.Company ConvertCompanyToData(Company value)
		{
			return new DATA_MODELS.Company
			{
				Email = value.Email,
				Name = value.Name,
				Password = value.Password,
			};
		}

		public static DATA_MODELS.Game ConvertGameToData(Game value)
		{
			var images = new List<DATA_MODELS.GameImage>();
			foreach (string url in value.ImageUrls)
			{
				images.Add(new DATA_MODELS.GameImage 
				{
					Url = url 
				});
			}
			
			return new DATA_MODELS.Game
			{
				CompanyName = value.CompanyName,
				CoverImage = value.CoverImage,
				Description = value.Description,
				Genre = ConvertGenreToData(value.Genre),
				State = ConvertGameStateToData(value.State),
				Images = images,
				IsFeatured = value.IsFeatured,
				Price = value.Price,
			};
		}

		public static DATA_MODELS.GameState ConvertGameStateToData(GameState value)
		{
			switch (value)
			{
				case GameState.Released:
					return DATA_MODELS.GameState.Released;
				case GameState.EarlyAccess:
					return DATA_MODELS.GameState.EarlyAccess;
				case GameState.Preorder:
					return DATA_MODELS.GameState.Preorder;
				default:
					throw new System.Exception($"Game state '{value}' is not supported in the current context");
			}
		}

		public static DATA_MODELS.Genre ConvertGenreToData(Genre value)
		{
			switch (value)
			{
				case Genre.Cooperative:
					return DATA_MODELS.Genre.Cooperative;
				case Genre.Action:
					return DATA_MODELS.Genre.Action;
				case Genre.ActionAdventure:
					return DATA_MODELS.Genre.ActionAdventure;
				case Genre.Adventure:
					return DATA_MODELS.Genre.Adventure;
				case Genre.Rpg:
					return DATA_MODELS.Genre.Rpg;
				case Genre.Simulation:
					return DATA_MODELS.Genre.Simulation;
				case Genre.Strategy:
					return DATA_MODELS.Genre.Strategy;
				case Genre.Sport:
					return DATA_MODELS.Genre.Sport;
				default:
					throw new System.Exception($"Genre '{value}' is not supported in the current context");
			}
		}

		public static DATA_MODELS.UserRole ConvertUserRoleToData(UserRole value)
		{
			switch (value)
			{
				case UserRole.Administrator:
					return DATA_MODELS.UserRole.Administrator;
				case UserRole.User:
					return DATA_MODELS.UserRole.User;
				default:
					throw new System.Exception($"User role '{value}' is not supported in the current context");
			}
		}
		#endregion
	}
}
