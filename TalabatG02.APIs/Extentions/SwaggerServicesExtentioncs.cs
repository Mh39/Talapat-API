﻿namespace TalabatG02.APIs.Extentions
{
    public static class SwaggerServicesExtentioncs
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }

        public static WebApplication UseSwaggerMiddleWares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
