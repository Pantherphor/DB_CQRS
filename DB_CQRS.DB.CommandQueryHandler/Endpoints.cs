using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DB_CQRS.DB.CommandQueryHandler
{
    public static class Endpoints
    {
        public static void MapEFDatabase(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
                 endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello: EFDatabase is up!");
                 }));
        }
    }
}
