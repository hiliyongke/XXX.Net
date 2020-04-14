// ──────────────────────────────────────────────────────────────
// 　文   件：ServiceCollectionExtensions.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 11:07
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#endregion

namespace XXX.Net.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API - V1",
                    Version = "v1",
                    Description = "A sample API ",
                    TermsOfService = new Uri("https://github.com/hiliyongke/XXX.Net"),
                    Contact = new OpenApiContact
                    {
                        Name = "YongkeLi",
                        Email = "249191296@qq.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });

                // 使用反射获取xml文件。并构造出文件的路径
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFile = $"XXX.Net.WebApi.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 启用xml注释. 该方法第二个参数启用控制器的注释，默认为false.
                options.IncludeXmlComments(xmlPath, true);

                #region 启用swagger验证功能

                var bearerScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };

                options.AddSecurityDefinition("Bearer", bearerScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    { bearerScheme, new List<string>()}

                });


                #endregion
            });
        }
    }
}