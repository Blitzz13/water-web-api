namespace Water.Services
{
	public interface IUserService
	{
		public AuthenticateResponse Authenticate(AuthenticateRequest model);
		public void Register(User model);
		public User GetById(string id);
		public User GetByUsername(string username);
	}
}