using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<AppUser, AppUserRole>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])),
                            ClockSkew = TimeSpan.Zero
                        }
                    );

            services.AddScoped<TokenService>();
            return services;
        }
    }
}