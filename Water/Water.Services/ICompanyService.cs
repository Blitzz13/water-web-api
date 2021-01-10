namespace Water.Services
{
	public interface ICompanyService
	{
		public AuthenticateResponse Authenticate(UserAuthenticateRequest model);
		public void Register(Company model);
		public Company GetById(string id);
		public Company GetByName(string name);
	}
}