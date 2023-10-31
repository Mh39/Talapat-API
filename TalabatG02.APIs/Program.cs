using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TalabatG02.APIs.Extentions;
using TalabatG02.APIs.MiddleWares;
using TalabatG02.Core.Entities.Identity;
using TalabatG02.Repository.Data;
using TalabatG02.Repository.Identity;

namespace TalabatG02.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services Work With DI

            // Add services to the container.

            builder.Services.AddControllers(); //Add Services ASP Web APIs
                                               //-----------------------------------------
                                               //--------Databases 
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(option =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });

            builder.Services.AddDbContext<AppIdentityDBContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            //-----------------------------------------
            //--------Extention Services
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddSwaggerServices();




            #endregion

            var app = builder.Build();
            #region UpdateDataBase Inside Main


            //Explicitly
            var Scope = app.Services.CreateScope();//Service Scoped  
            var Services = Scope.ServiceProvider;//DI
                                                 //LoggerFactory
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = Services.GetRequiredService<StoreContext>();//Ask Clr to Create Object From ScopeText Explicity
                await dbContext.Database.MigrateAsync();//Update-Database
                await StoreContextSeed.SeedAsync(dbContext);

                var identityDbcontext = Services.GetRequiredService<AppIdentityDBContext>();
                await identityDbcontext.Database.MigrateAsync();//Update-Database

                var userManager = Services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextSeed.SeeedUsersAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an Error Occured during apply The Migration");

            }
            #endregion
            #region Configure Request into pipeline

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleWares();
            }

            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseAuthentication();
            app.UseAuthorization();


            //app.UseRouting(); //Routing Table 
            //app.UseEndpoints(endpoints => { });
            app.MapControllers(); //Controller
            #endregion

            app.Run();
        }
    }
}