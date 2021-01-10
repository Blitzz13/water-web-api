namespace Water.Services
{
	public interface IGameService
	{
		public void AddGame(Company model);
		public Company Remove(string id);
	}
}
