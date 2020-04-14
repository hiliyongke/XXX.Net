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
using XXX.Net.Swagger.Options;

#endregion

namespace XXX.Net.Swagger
{
    public static class SwaggerExtensions
    {
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            UseCustomSwagger(app, () => new CustomOptions());
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, Func<CustomOptions> func)
        {
            var options = func.Invoke();
            app.UseSwagger(opt =>
            {
                if (options.UseSwaggerAction == null) return;
                options.UseSwaggerAction(opt);
            });
            app.UseSwaggerUI(c =>
            {
                if (options.ApiVersions == null) return;
                c.RoutePrefix = options.RoutePrefix;
                c.DocumentTitle = options.ProjectName;
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1); //不显示model
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                c.ShowExtensions();
                if (options.UseCustomIndex) c.UseCustomSwaggerIndex();
                foreach (var item in options.ApiVersions) c.SwaggerEndpoint($"/swagger/{item}/swagger.json", $"{item}");
                options.UseSwaggerUIAction?.Invoke(c);
            });
        }

        /// <summary>
        ///     使用自定义首页
        /// </summary>
        /// <returns></returns>
        public static void UseCustomSwaggerIndex(this SwaggerUIOptions c)
        {
            var currentAssembly = typeof(CustomOptions).GetTypeInfo().Assembly;
            c.IndexStream = () =>
                currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.index.html");
        }
    }
}