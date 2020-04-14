// ──────────────────────────────────────────────────────────────
// 　文   件：SwaggerExtensions.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 11:07
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

#endregion

namespace XXX.Net.Swagger
{
    public static class SwaggerExtensions
    {
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }


    }
}