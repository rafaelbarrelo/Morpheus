using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Morpheus.API.Validation;

namespace Morpheus.API.Middlewares
{
    public class ValidationMiddleware
	{
		private readonly ILogger<ValidationMiddleware>  _logger;
		private readonly RequestDelegate _next;
		private readonly RouteValidator _routeValidator;

		public ValidationMiddleware(ILogger<ValidationMiddleware> logger, RouteValidator routeValidator, RequestDelegate next)
		{
			_routeValidator = routeValidator;
			_logger = logger;
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				_logger.LogDebug($"ValidationMiddleware");

				var key = context.Request.Path.Value;
				var validator = _routeValidator.Resolve(key);
				if (validator != null){
					validator.Context = context;
					context.Items["validator"] = validator;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.ToString());
			}

			await _next(context);
		}
	}
}
