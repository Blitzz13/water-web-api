using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Water.Services.Impl.Helpers
{
	public static class Token
	{
		private const long _tokenExpirationInMinutes = 60;

		public static TokenProvider GenerateJwtToken(string id, AppSettings appSettings)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
				Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationInMinutes),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			return new TokenProvider
			{
				Token = tokenHandler.WriteToken(token),
				ExpiresInSeconds = _tokenExpirationInMinutes * 60,
			};
		}
	}
}
