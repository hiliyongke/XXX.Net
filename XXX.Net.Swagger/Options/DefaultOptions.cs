// ──────────────────────────────────────────────────────────────
// 　文   件：DefaultOptions.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 11:07
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace XXX.Net.Swagger.Options
{
    public class DefaultOptions
    {
        public static CustomOptions GetSwaggerOptions(string apiXml)
        {
            return new CustomOptions
            {
                ProjectName = "xxx WebAPI",
                ApiVersions = new[] {"v1", "v2"},
                Descrption = "描述",
                UseCustomIndex = false,
                RoutePrefix = string.Empty,
                AddSwaggerGenAction = c =>
                {
                    var filePath = Path.Combine(AppContext.BaseDirectory, apiXml);
                    c.IncludeXmlComments(filePath, true);
                    c.CustomSchemaIds(x => x.FullName);
                },
                UseSwaggerAction = c => { },
                UseSwaggerUIAction = c => { }
            };
        }
    }
}