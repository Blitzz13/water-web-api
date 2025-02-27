﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Water.Services.Impl.Helpers
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user = (User)context.HttpContext.Items["User"];	
			
			if (user.Role != UserRole.Administrator)
			{
				context.Result = new JsonResult(new { message = "You cannot perform action." }) { StatusCode = StatusCodes.Status403Forbidden };
			}
		}
	}
}
