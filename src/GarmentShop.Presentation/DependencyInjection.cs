using GarmentShop.Presentation.Common.Errors;
using GarmentShop.Presentation.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GarmentShop.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();

            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, GarmentShopProblemDetailsFactory>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
