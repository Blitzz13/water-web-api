using Microsoft.AspNetCore.Mvc;
using System;
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
	public class UsersController : ControllerBase
	{
		private IUserService _userService;

		/// <summary>
		/// User controller constructor
		/// </summary>
		/// <param name="userService"></param>
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		/// <summary>
		/// Authenticates the given login request
		/// </summary>
		/// <param name="model"><see cref="AuthenticateRequest"/>Authentication request model</param>
		/// <returns> Authenticated user data </returns>
		/// <response code="200"><see cref="AuthenticateResponse" />Authentication response</response>
		/// <response code="400"><see cref="Error"/>Bad request</response>
		[HttpPost("Authenticate")]
		public ActionResult<Entities.AuthenticateResponse> Authenticate([FromBody]AuthenticateRequest model)
		{
			UserAuthenticateRequest serviceModel = Converter.ConvertAuthenticateRequestToService(model);
			Entities.AuthenticateResponse response = Converter.ConvertAuthenticateResponseToEntity(_userService.Authenticate(serviceModel));

			if (response == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}

			return Ok(response);
		}

		/// <summary>
		/// Gets user by given id
		/// </summary>
		/// <param name="id"><see cref="string"/> User id </param>
		/// <returns> User model </returns>
		/// <response code="200"><see cref="UserItem" />User model</response>
		/// <response code="400"><see cref="Error"/>Bad request</response>
		[HttpGet("User/{id?}")]
		public ActionResult<UserItem> GetUserById([FromRoute]string id)
		{
			try
			{
				Entities.User user = Converter.ConvertUserToEntity(_userService.GetById(id));

				return Ok(user);
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
		/// Authenticates the given login request
		/// </summary>
		/// <returns> Authenticated user data </returns>
		/// <response code="200"><see cref="AuthenticateResponse" />Authentication response</response>
		/// <response code="400"><see cref="Error"/>Bad request</response>
		[HttpGet("Test")]
		[Authenticate]
		public ActionResult<string> Test()
		{
			return "It worked";
		}

		/// <summary>
		/// Registers a user
		/// </summary>
		/// <param name="model" in="body"><see cref="Entities.User"/>Register user model</param>
		/// <returns> Register message </returns>
		/// <response code="200"><see cref="OkResult" />Ok response with message</response>
		/// <response code="400"><see cref="BadRequestObjectResult"/>Bad request with the exception</response>
		[HttpPost("Register")]
		public IActionResult Register([FromBody]Entities.User model)
		{
			try
			{
				_userService.Register(Converter.ConvertUserToService(model));
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
		/// Adds a game to the user games enumeration
		/// </summary>
		/// <param name="request" in="body"><see cref="BuyGameRequest"/>Register user model</param>
		/// <returns> Register message </returns>
		/// <response code="200"><see cref="void" />Ok response</response>
		[HttpPost("Buy/Game")]
		[Authenticate]
		public void BuyGame([FromBody]BuyGameRequest request)
		{
			try
			{
				_userService.BuyGame(request.userId, int.Parse(request.gameId));
			}
			catch (Exception e)
			{
				throw new Exception(e.Message, e.InnerException);
			}
		}
	}
}
