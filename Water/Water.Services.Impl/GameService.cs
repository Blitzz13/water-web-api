using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DATA = Water.Data;

namespace Water.Services.Impl
{
	public class GameService : IGameService
	{
		private readonly DATA.WaterDbConext _context;

		public GameService()
		{
			_context = new DATA.WaterDbConext();
		}

		public int AddGame(Game model)
		{
			if (model.CompanyName.Length < 2)
			{
				throw new Exception("The company name should be atleast 2 characters");
			}

			if (string.IsNullOrEmpty(model.CoverImage) || string.IsNullOrWhiteSpace(model.CoverImage))
			{
				throw new Exception("Cover image must have link to an image");
			}

			if (model.ImageUrls.Count <= 0)
			{
				throw new Exception("There should be atleast 1 image");
			}

			DATA.Models.Game game = Conversions.Converter.ConvertGameToData(model);

			_context.Add(game);
			_context.SaveChanges();
			return game.Id;
		}

		public Game GetById(int id)
		{
			DATA.Models.Game game = _context.Games.FirstOrDefault(x => x.Id == id);
			return Conversions.Converter.ConvertGameToService(game);
		}

		public Game[] FindGamesByName(string name)
		{
			Game[] games = _context.Games.Where(x => x.Name.Contains(name)).Select(Conversions.Converter.ConvertGameToService).ToArray();
			return games;
		}

		public Game[] ListUserGamesById(string userId)
		{
			Game[] games = _context.Users.Include(user => user.UserGames)
				.ThenInclude(row => row.Game)
				.First(x => x.Id == userId)
				.UserGames
				.Select(x => Conversions.Converter.ConvertGameToService(x.Game))
				.ToArray();
			
			return games;
		}

		public void Remove(string id)
		{
			DATA.Models.Game game = _context.Games.First(u => u.Id == int.Parse(id));

			_context.Games.Remove(game);
			_context.SaveChanges();
		}
	}
}
