using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Authentication;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Services;
using alone_mysql_dc_comics.Services.CharacterService;
using alone_mysql_dc_comics.Services.FamilyService;
using alone_mysql_dc_comics.Services.PowerService;
using alone_mysql_dc_comics.Services.TeamService;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace alone_mysql_dc_comics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DcDbContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup ));
            services.AddScoped<ICharacterService,CharacterService>();
            services.AddScoped<IFamilyService,FamilyService>();
            services.AddScoped<ITeamService,TeamService>();
            services.AddScoped<IPowerService,PowerService>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters{
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                             .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                             ValidateIssuer = false,
                             ValidateAudience = false  
                        };
                    });
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
    }
}
