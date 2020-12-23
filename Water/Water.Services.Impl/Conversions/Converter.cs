using DATA_MODELS = Water.Data.Models;
namespace Water.Services.Impl.Conversions
{
	class Converter
	{
		#region Convert to service
		public User ConvertUserToService(DATA_MODELS.User value)
		{
			return new User
			{
				Email = value.Email,
				FullName = value.Email,
				Password = value.Password,
				Username = value.Username,

			};
		}
		#endregion

		#region Convert to data
		public DATA_MODELS.User ConvertUserToData(User value)
		{
			return new DATA_MODELS.User
			{
				Email = value.Email,
				FullName = value.Email,
				Password = value.Password,
				Username = value.Username,
				Role = ConvertUserRoleToData(value.Role)
			};
		}

		public DATA_MODELS.UserRole ConvertUserRoleToData(UserRole value)
		{
			switch (value)
			{
				case UserRole.Administrator:
					return DATA_MODELS.UserRole.Administrator;
				case UserRole.User:
					return DATA_MODELS.UserRole.User;
				case UserRole.Company:
					return DATA_MODELS.UserRole.Company;
				default:
					throw new System.Exception($"User role {value} is not supported in the current context");
			}
		}
		#endregion
	}
}
