// ──────────────────────────────────────────────────────────────
// 　文   件：CustomOptions.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 11:07
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using System;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

#endregion

namespace XXX.Net.Swagger.Options
{
    public class CustomOptions
    {
        /// <summary>
        ///     项目名称
        /// </summary>
        public string ProjectName { get; set; } = "XXX api";

        /// <summary>
        ///     接口文档显示版本
        /// </summary>
        public string[] ApiVersions { get; set; }

        /// <summary>
        ///     接口文档访问路由前缀
        /// </summary>
        public string RoutePrefix { get; set; } = "swagger";

        /// <summary>
        ///     使用自定义首页
        /// </summary>
        public bool UseCustomIndex { get; set; }

        public string Descrption { get; set; }


        /// <summary>
        ///     UseSwagger Hook
        /// </summary>
        public Action<SwaggerOptions> UseSwaggerAction { get; set; }

        /// <summary>
        ///     UseSwaggerUI Hook
        /// </summary>
        public Action<SwaggerUIOptions> UseSwaggerUIAction { get; set; }

        /// <summary>
        ///     AddSwaggerGen Hook
        /// </summary>
        public Action<SwaggerGenOptions> AddSwaggerGenAction { get; set; }
    }
}