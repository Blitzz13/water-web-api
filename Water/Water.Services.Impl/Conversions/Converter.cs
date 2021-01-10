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
