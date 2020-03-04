using BlogApi.ExceptionHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApi
{
    public static class ServiceInjector
    {
        public static void AddFilterControllers(this IServiceCollection services){
            services.AddControllers(options =>
                options.Filters.Add(new ExceptionFilter())).AddXmlSerializerFormatters();
        }
        public static void AddJwtBearer(this IServiceCollection services,IConfiguration configuration){
            services.AddAuthentication(authOptions=>{
                authOptions.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions=>{
                jwtOptions.SaveToken=true;
                jwtOptions.TokenValidationParameters=new TokenValidationParameters{
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer=configuration["JwtCredentials:ValidIssuer"],
                    ValidAudience=configuration["JwtCredentials:ValidAudience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtCredentials:Key"]))
                };
            });

        }
    }
}