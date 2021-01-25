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

		public Game[] FindGamesByName(string name)
		{
			Game[] games = _context.Games.Where(x => x.Name.Contains(name)).Select(Conversions.Converter.ConvertGameToService).ToArray();
			return games;
		}

		public Game GetById(int id)
		{
			DATA.Models.Game game = _context.Games.Include(game => game.Images).Where(x => x.Id == id).First();
			return Conversions.Converter.ConvertGameToService(game);
		}

		public GameItem[] ListUserGamesById(string userId)
		{
			GameItem[] games = _context.Users.Include(user => user.UserGames)
				.ThenInclude(row => row.Game)
				.First(x => x.Id == userId)
				.UserGames
				.Select(x => Conversions.Converter.ConvertGameToItem(x.Game))
				.ToArray();

			return games;
		}

		public void Remove(string id)
		{
			DATA.Models.Game game = _context.Games.First(u => u.Id == int.Parse(id));

			_context.Games.Remove(game);
			_context.SaveChanges();
		}

		public GameItem[] ListGameItems(GameFilter filter)
		{
			var games = new List<GameItem>();

			if (filter.Id != null)
			{
				DATA.Models.Game game = _context.Games.FirstOrDefault(x => x.Id == int.Parse(filter.Id));
				games.Add(Conversions.Converter.ConvertGameToItem(game));
				return games.ToArray();
			}

			if (filter.isFeatured)
			{
				DATA.Models.Game[] dataGames = _context.Games.Where(x => x.IsFeatured == filter.isFeatured).ToArray();
				games.AddRange(dataGames.Select(x => Conversions.Converter.ConvertGameToItem(x)));
			}

			if (filter.Name != null)
			{
				DATA.Models.Game[] dataGames = _context.Games.Where(x => x.Name.Contains(filter.Name)).ToArray();
				games.AddRange(dataGames.Select(x => Conversions.Converter.ConvertGameToItem(x)));
			}

			if (filter.Genres.Length > 0)
			{
				int dataGenre = (int)Conversions.Converter.ConvertGenreToData(filter.Genres[0]);
				DATA.Models.Game[] dataGames = _context.Games.Where(x => (int)x.Genre == dataGenre).ToArray();
				games.AddRange(dataGames.Select(x => Conversions.Converter.ConvertGameToItem(x)));
			}

			if (filter.States.Length > 0)
			{
				int dataState = (int)Conversions.Converter.ConvertGameStateToData(filter.States[0]);
				DATA.Models.Game[] dataGames = _context.Games.Where(x => (int)x.State == dataState).ToArray();
				games.AddRange(dataGames.Select(x => Conversions.Converter.ConvertGameToItem(x)));
			}

			games = games.Distinct().ToList();

			return games.ToArray();
		}

		public int UpdateGame(Game model)
		{
			DATA.Models.Game game = _context.Games.Include(game => game.Images).Where(x => x.Id == int.Parse(model.Id)).First();

			if (game == null)
			{
				throw new Exception($"Game \"{model.Name}\" does not exist.");
			}

			if (!string.IsNullOrEmpty(model.Name))
			{
				game.Name = model.Name;
			}

			if (!string.IsNullOrEmpty(model.CompanyName))
			{
				game.CompanyName = model.CompanyName;
			}

			if (!string.IsNullOrEmpty(model.Description))
			{
				game.Description = model.Description;
			}

			if (!string.IsNullOrEmpty(model.CoverImage))
			{
				game.CoverImage = model.CoverImage;
			}

			if (model.ImageUrls.Count > 0)
			{
				game.Images.Clear();
				
				foreach (string url in model.ImageUrls)
				{
					game.Images.Add(new DATA.Models.GameImage
					{
						Url = url
					});
				}
			}

			game.Genre = Conversions.Converter.ConvertGenreToData(model.Genre);

			game.State = Conversions.Converter.ConvertGameStateToData(model.State);

			game.IsFeatured = model.IsFeatured;

			_context.SaveChanges();

			return game.Id;
		}
	}
}
