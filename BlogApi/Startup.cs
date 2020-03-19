using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BlogApi.Data.Models;
using BlogApi.ExceptionHandler;
using BlogApi.Data.Repository;
using AutoMapper;
using BlogApi.Services;
using BlogApi.Jwt;

namespace BlogApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtModel>(Configuration.GetSection("JwtModel"));
            services.AddDbContext<BlogContext>
            (opt=>opt.UseSqlServer(Configuration["ConnectionStrings:BlogContext"]));
            services.AddControllers(options =>
                options.Filters.Add(new ExceptionFilter())).AddXmlSerializerFormatters();
            services.AddJwtBearer(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                                              .AllowAnyOrigin()
                                              .AllowAnyMethod()
                                              .AllowAnyHeader();
                });
            });
        
        services.AddScoped<IRepository,BlogRepository>();    
            services.AddScoped<IUserRepo,UserRepo>();    
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IUserService,UserService>();
            services.AddSingleton<JwtOptions>();
            services.AddAutoMapper(typeof(AutoMapping));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
    
            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
