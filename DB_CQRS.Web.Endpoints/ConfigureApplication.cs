using Microsoft.AspNetCore.Builder;

namespace DB_CQRS.Web.Endpoints
{
    public static class ConfigureApplication
    {
        public static void UseSwaggerUIGenerator(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB_CQRS.UI v1"));
        }
    }
}
