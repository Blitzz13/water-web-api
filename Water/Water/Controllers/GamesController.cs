using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Water.Entities;
using Water.Services;
using Water.Services.Impl.Helpers;

namespace Water.Controllers
{
	/// <summary>
	/// Represents user controller
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class GamesController : ControllerBase
	{
		private IGameService _gamesService;

		/// <summary>
		/// Games controller constructor
		/// </summary>
		/// <param name="gameService"></param>
		public GamesController(IGameService gameService)
		{
			_gamesService = gameService;
		}

		/// <summary>
		/// Creates a game
		/// </summary>
		/// <param name="model"><see cref="AddGameRequest"/> Add game request </param>
		/// <returns> The game id </returns>
		/// <response code="200"><see cref="Game" /> Game object </response>
		/// <response code="400"><see cref="Error"/> Bad request with the exception </response>
		[HttpPost("Add")]
		[Authorize]
		[Authenticate]
		public ActionResult<string> AddGame([FromBody]AddGameRequest model)
		{
			try
			{
				int id = _gamesService.AddGame(Converter.ConvertAddGameRequestToService(model));
				return Ok(id);
			}
			catch (Exception e)
			{
				return BadRequest(new Error
				{
					Message = e.Message,
					StackTrace = e.StackTrace.Trim(),
				});
			}
		}

		/// <summary>
		/// Removes a game from the database
		/// </summary>
		/// <param name="id"><see cref="string"/>User Id</param>
		/// <response code="200"><see cref="Game" /> Game object </response>
		/// <response code="400"><see cref="Error"/> Bad request with the exception </response>
		[HttpPost("Remove/{id?}")]
		[Authorize]
		[Authenticate]
		public IActionResult RemoveGame([FromRoute]string id)
		{
			try
			{
				_gamesService.Remove(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(new Error
				{
					Message = e.Message,
					StackTrace = e.StackTrace.Trim(),
				});
			}
		}

		/// <summary>
		/// Gets game by given id
		/// </summary>
		/// <param name="id"><see cref="string"/> Game id </param>
		/// <returns> Game </returns>
		/// <response code="200"><see cref="Game" /> Game object </response>
		/// <response code="400"><see cref="Error"/> Bad request with the exception </response>
		[HttpGet("Game/{id?}")]
		public ActionResult<Entities.Game> GetGameById([FromRoute]string id)
		{
			try
			{
				Entities.Game game = Converter.ConvertGameToEntity(_gamesService.GetById(int.Parse(id)));

				return Ok(game);
			}
			catch (Exception e)
			{
				return BadRequest(new Error
				{
					Message = e.Message,
					StackTrace = e.StackTrace.Trim(),
				});
			}
		}

		/// <summary>
		/// Returns the purchased games for the given user id
		/// </summary>
		/// <param name="id"><see cref="string"/> User id </param>
		/// <returns> Enumeration of games </returns>
		/// <response code="200"><see cref="GameItem" /> Enumeration of game items </response>
		/// <response code="400"><see cref="Error"/> Bad request with the exception </response>
		[HttpGet("User/Games/{id}")]
		public ActionResult<Entities.GameItem[]> ListUserGames([FromRoute]string id)
		{
			try
			{
				Entities.GameItem[] games = _gamesService.ListUserGamesById(id).Select(Converter.ConvertGameItemToEntity).ToArray();

				return Ok(games);
			}
			catch (Exception e)
			{
				return BadRequest(new Error
				{
					Message = e.Message,
					StackTrace = e.StackTrace.Trim(),
				});
			}
		}

		/// <summary>
		/// Returns the purchased games for the given user id
		/// </summary>
		/// <param name="filter"><see cref="GameFilter"/> Game filter </param>
		/// <returns> Enumeration of game game items </returns>
		/// <response code="200"><see cref="GameItem" /> Enumeration of game items </response>
		/// <response code="400"><see cref="Error"/> Bad request with the exception </response>
		[HttpPost("List")]
		public ActionResult<Entities.GameItem[]> ListGameItems([FromBody]Entities.GameFilter filter)
		{
			try
			{
				Services.GameFilter serviceFilter = Converter.ConvertGameFilterToService(filter);
				Entities.GameItem[] games = _gamesService.ListGameItems(serviceFilter).Select(Converter.ConvertGameItemToEntity).ToArray();

				return Ok(games);
			}
			catch (Exception e)
			{
				return BadRequest(new Error
				{
					Message = e.Message,
					StackTrace = e.StackTrace.Trim(),
				});
			}
		}
	}
}
