using Microsoft.AspNetCore.Mvc;
using System;
using Water.Services;
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
		/// <param name="model"><see cref="Entities.AuthenticateRequest"/>Authentication request model</param>
		/// <returns> Authenticated user data </returns>
		/// <response code="200"><see cref="Entities.AuthenticateResponse" />Authentication response</response>
		/// <response code="400"><see cref="BadRequestObjectResult"/>Bad request</response>
		[HttpPost("Authenticate")]
		public ActionResult<Entities.AuthenticateResponse> Authenticate(Entities.AuthenticateRequest model)
		{
			AuthenticateRequest serviceModel = Converter.ConvertAuthenticateRequestToService(model);
			Entities.AuthenticateResponse response = Converter.ConvertAuthenticateResponseToEntity(_userService.Authenticate(serviceModel));

			if (response == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}

			return Ok(response);
		}

		/// <summary>
		/// Registers a user
		/// </summary>
		/// <param name="model" in="body"><see cref="Entities.User"/>Register user model</param>
		/// <returns> Register message </returns>
		/// <response code="200"><see cref="OkResult" />Ok response</response>
		/// <response code="400"><see cref="BadRequestObjectResult"/>Bad request</response>
		[HttpPost("Register")]
		public ActionResult<string> Register(Entities.User model)
		{
			try
			{
				_userService.Register(Converter.ConvertUserToService(model));
				return Ok("Register is succesful");
			}
			catch (Exception e)
			{
				return BadRequest(new { message = e.Message });
			}
		}
	}
}
