using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CQRS.DB.EntityFrameword
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
