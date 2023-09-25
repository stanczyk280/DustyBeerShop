using DustyBeerShop.API.Repository;
using DustyBeerShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DustyBeerShop.API.Commons.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options => options
                .UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IBeerRepository), typeof(BeerRepository));
            //cors policy allowing to safely retrive data returned by our api so the client-app can use the data
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            return services;
        }
    }
}