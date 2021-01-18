namespace Water.Services
{
	public interface IGameService
	{
		public int AddGame(Game model);

		public void Remove(string id);

		public Game[] FindGamesByName(string name);

		public Game GetById(int id);

		public GameItem[] ListUserGamesById(string id);

		public GameItem[] ListGameItems(GameFilter filter);
	}
}
