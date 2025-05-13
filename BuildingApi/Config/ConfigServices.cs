using DataAccess.Common;
using DataAccess.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using Utilities.ExtensionMethod;
using Utilities.Utilities;

namespace BuildingApi.Config
{
    public static class ConfigServices
    {
        public static void AddDocumentation(this IServiceCollection services)
        {
            services.AddOpenApi();
        }

        public static void UseDocumentation(this IEndpointRouteBuilder app)
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        public static void AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(ConstantsConfig.ConfigurationCorsPolicy, builder => builder                
                .WithOrigins(Environment.GetEnvironmentVariable(ConstantsConfig.ConfigurationApplicationCors).ValidateValue().Split("|"))                
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
        }

        public static void AddAutentication(this IServiceCollection services)
        {            
            var jwtKey = Environment.GetEnvironmentVariable(ConstantsConfig.JwtKey).ValidateValue();            
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable(ConstantsConfig.JwtIssuer).ValidateValue(),
                    ValidAudience = Environment.GetEnvironmentVariable(ConstantsConfig.JwtAudience).ValidateValue(),                    
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });

            services.AddAuthorization();
        }

        public static void AddDatabase(this IServiceCollection services)
        {                        
            var connectionString = Environment.GetEnvironmentVariable(ConstantsConfig.ConectionStringDataBase).ValidateValue();

            services.AddDbContext<MainContext>(options => options
                        .UseSqlServer(connectionString)
                        .UseLazyLoadingProxies()
                    );
            services.AddScoped<IMainContext>(provider => provider.GetService<MainContext>()!);


            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<MainContext>();
                    context.Database.Migrate();
                }
            }
        }

        public static void AddInvalidModelMiddleware(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value?.Errors.Any() == true) 
                        .ToDictionary(
                            e => e.Key,
                            e => e.Value!.Errors.Select(err => err.ErrorMessage).ToArray() 
                        );

                    return new BadRequestObjectResult(new
                    {
                        message = ConstantsException.ModelInvalid,
                        errors
                    });
                };
            });
        }
    }
}
