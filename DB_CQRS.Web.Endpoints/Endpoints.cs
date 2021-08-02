using Microsoft.AspNetCore.Builder;

namespace DB_CQRS.Web.Endpoints
{
    public static class Endpoints
    {
        public static void MapSaveOrders(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
