using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using DATA = Water.Data;

namespace Water.Services.Impl
{
	public class UserService : IUserService
	{
		private readonly DATA.WaterDbConext _context;
		private const long _tokenExpirationInMinutes = 60;
		private const long _tokenExpirationTimeInSecond = _tokenExpirationInMinutes * 60;
		private readonly AppSettings _appSettings;

		public UserService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
			_context = new DATA.WaterDbConext();

		}

		public AuthenticateResponse Authenticate(AuthenticateRequest model)
		{
			var user = GetByUsername(model.Username);
			
			if (user == null)
			{
				throw new Exception("Wrong username or passowrd");
			}

			byte[] hashBytes, hash;
			Helpers.Password.UnhashPassword(model.Password, user, out hashBytes, out hash);
			Helpers.Password.ValidatePassword(hashBytes, hash);
			string token = GenerateJwtToken(user);

			var result = new AuthenticateResponse
			{
				Id = user.Id,
				Username = user.Username,
				FullName = user.FullName,
				Role = user.Role,
				TokenProvider = new TokenProvider
				{
					ExpiresInSeconds = _tokenExpirationTimeInSecond,
					Token = token,
				}
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
			throw new NotImplementedException();
		}

		public User GetByUsername(string username)
		{
			DATA.Models.User dataUser = _context.Users.SingleOrDefault(x => x.Username == username);

			return Conversions.Converter.ConvertUserToService(dataUser);
		}

		// helper methods

		private string GenerateJwtToken(User user)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
				Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationInMinutes),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
