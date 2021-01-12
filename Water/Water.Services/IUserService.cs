namespace Water.Services
{
	public interface IUserService
	{
		public AuthenticateResponse Authenticate(UserAuthenticateRequest model);
		
		public void Register(User model);
		
		public User GetById(string id);
		
		public User GetByUsername(string username);

		public void BuyGame(string userId, int gameId);
	}
}