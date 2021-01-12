using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DATA = Water.Data;

namespace Water.Services.Impl
{
	public class UserService : IUserService
	{
		private readonly DATA.WaterDbConext _context;
		private readonly AppSettings _appSettings;

		public UserService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
			_context = new DATA.WaterDbConext();
		}

		public AuthenticateResponse Authenticate(UserAuthenticateRequest model)
		{
			User user = GetByUsername(model.Username);
			
			if (user == null)
			{
				throw new Exception("Wrong username or passowrd");
			}

			byte[] hashBytes, hash;
			Helpers.Password.UnhashPassword(model.Password, user, out hashBytes, out hash);
			Helpers.Password.ValidatePassword(hashBytes, hash);
			TokenProvider tokenProvider = Helpers.Token.GenerateJwtToken(user.Id, _appSettings);

			var result = new AuthenticateResponse
			{
				Id = user.Id,
				Username = user.Username,
				FullName = user.FullName,
				Role = user.Role,
				TokenProvider = tokenProvider,
			};

			return result;
		}

		public void Register(User model)
		{
			if (string.IsNullOrEmpty(model.Username))
			{
				throw new Exception("Your username cannot be empty.");
			}

			if (_context.Users.Any(u => u.Username == model.Username))
			{
				throw new Exception("The username you have chosen already exists.");
			}

			if (string.IsNullOrEmpty(model.Email))
			{
				throw new Exception("The email cannot be empty");
			}

			var regex = new Regex(@"^([0-9a-zA-Z_]([_+-.\w]*[0-9a-zA-Z_])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
			Match match = regex.Match(model.Email);
			
			if (!match.Success)
			{
				throw new Exception("The email you enterted is in incorrect format");
			}

			if (model.Username.Length < 2)
			{
				throw new Exception("The username should be atleast 2 characters");
			}

			string password = Helpers.Password.HashPassword(model.Password);

			DATA.Models.User user = new DATA.Models.User();

			user = new DATA.Models.User
			{
				Username = model.Username,
				Password = password,
				Email = model.Email,
				FullName = model?.FullName,
			};

			_context.Add(user);
			_context.SaveChanges();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User GetById(string id)
		{
			DATA.Models.User user = _context.Users.FirstOrDefault(u => u.Id == id);
			return Conversions.Converter.ConvertUserToService(user);
		}

		public User GetByUsername(string username)
		{
			DATA.Models.User dataUser = _context.Users.SingleOrDefault(x => x.Username == username);

			return Conversions.Converter.ConvertUserToService(dataUser);
		}

		public void BuyGame(string userId, int gameId)
		{
			DATA.Models.Game game = _context.Games.FirstOrDefault(g => g.Id == gameId);
			if(game != null)
			{
				return;
			}

			DATA.Models.User user = _context.Users.FirstOrDefault(u => u.Id == userId);
			user.UserGames.Add(new DATA.Models.UserGame
			{
				GameId = gameId,
				UserId = userId
			});

			_context.SaveChanges();
		}
	}
}
