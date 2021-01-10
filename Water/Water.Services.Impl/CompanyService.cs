using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DATA = Water.Data;

namespace Water.Services.Impl
{
	public class CompanyService : ICompanyService
	{
		private readonly DATA.WaterDbConext _context;
		private const long _tokenExpirationInMinutes = 60;
		private const long _tokenExpirationTimeInSecond = _tokenExpirationInMinutes * 60;
		private readonly AppSettings _appSettings;

		public CompanyService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
			_context = new DATA.WaterDbConext();
		}

		public AuthenticateResponse Authenticate(UserAuthenticateRequest model)
		{
			//User user = GetByUsername(model.Username);

			//if (user == null)
			//{
			//	throw new Exception("Wrong username or passowrd");
			//}

			//byte[] hashBytes, hash;
			//Helpers.Password.UnhashPassword(model.Password, user, out hashBytes, out hash);
			//Helpers.Password.ValidatePassword(hashBytes, hash);
			//string token = Helpers.Token.GenerateJwtToken();

			//var result = new AuthenticateResponse
			//{
			//	Id = user.Id,
			//	Username = user.Username,
			//	FullName = user.FullName,
			//	Role = user.Role,
			//	TokenProvider = new TokenProvider
			//	{
			//		ExpiresInSeconds = _tokenExpirationTimeInSecond,
			//		Token = token,
			//	}
			//};

			return null;
		}

		public void Register(Company model)
		{
			if (string.IsNullOrEmpty(model.Name))
			{
				throw new Exception("Your username cannot be empty.");
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

			if (model.Name.Length < 2)
			{
				throw new Exception("The company name should be atleast 2 characters");
			}

			string password = Helpers.Password.HashPassword(model.Password);

			DATA.Models.Company company = new DATA.Models.Company();

			company = new DATA.Models.Company
			{
				Name = model.Name,
				Password = password,
				Email = model.Email,
			};

			_context.Add(company);
			_context.SaveChanges();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public Company GetById(string id)
		{
			DATA.Models.Company company = _context.Companies.FirstOrDefault(u => u.Id == id);
			return Conversions.Converter.ConvertCompanyToService(company);
		}

		public Company GetByName(string name)
		{
			DATA.Models.Company dataCompany = _context.Companies.SingleOrDefault(x => x.Name == name);

			return Conversions.Converter.ConvertCompanyToService(dataCompany);
		}

	}
}
