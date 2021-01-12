using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using NSwag;
using NSwag.Generation.Processors.Security;
using Water.Services;
using Water.Services.Impl;
using Water.Services.Impl.Helpers;

namespace Water
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});

			services.AddControllers()
					.AddNewtonsoftJson(options =>
					{
						options.SerializerSettings.Converters.Add(new StringEnumConverter());
					});

			// configure strongly typed settings object
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

			// configure DI for application services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGameService, GameService>();

			services.AddOpenApiDocument(settings =>
			{
				settings.SchemaGenerator.Settings.SchemaType = NJsonSchema.SchemaType.OpenApi3;
				settings.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Example API";
					document.Info.Description = "REST API for example.";
				};

				settings.AddSecurity("JWT", new NSwag.OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
					Name = "Authorization",
					In = OpenApiSecurityApiKeyLocation.Header,
					Type = OpenApiSecuritySchemeType.ApiKey,
				});

				settings.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

				//settings.OperationProcessors.Add(new CustomHeader());
			});

			//services.AddSwaggerGen(c =>
			//{
			//	c.SwaggerDoc("v1", new OpenApiInfo
			//	{
			//		Title = "My API",
			//		Version = "v1",
			//	});

			//	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			//	{
			//		In = ParameterLocation.Header,
			//		Description = "Please insert JWT with Bearer into field",
			//		Name = "Authorization",
			//		Type = SecuritySchemeType.ApiKey
			//	});

			//	c.AddSecurityRequirement(new OpenApiSecurityRequirement
			//	{
			//		{
			//			new OpenApiSecurityScheme
			//			{
			//				Reference = new OpenApiReference
			//				{
			//					Type = ReferenceType.SecurityScheme,
			//					Id = "Bearer"
			//				}
			//			},
			//			new string[] { }
			//		}
			//	});
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseMiddleware<JwtMiddleware>();

			app.UseOpenApi();

			app.UseSwaggerUi3();

			app.UseCors("CorsPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
