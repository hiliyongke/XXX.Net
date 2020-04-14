// ──────────────────────────────────────────────────────────────
// 　文   件：ServiceCollectionExtensions.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 11:07
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using XXX.Net.Swagger.Options;

#endregion

namespace XXX.Net.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            AddCustomSwagger(services, () => new CustomOptions());
        }

        public static void AddCustomSwagger(this IServiceCollection services, Func<CustomOptions> func)
        {
            var options = func.Invoke();
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "");

            services.AddSwaggerGen(c =>
            {
                if (options.ApiVersions == null) return;
                foreach (var version in options.ApiVersions)
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Title = options.ProjectName,
                        Version = version,
                        Description = options.Descrption,
                        Contact = new OpenApiContact {Name = "YongkeLi", Email = "249191296@qq.com"}
                    });

                #region 添加header验证信息

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Name = "Authorization", //jwt默认的参数名称
                    In = ParameterLocation.Header, //jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                #endregion

                //c.OperationFilter<SwaggerDefaultValueFilter>();
                //c.OperationFilter<SwaggerFileUploadFilter>();
                options.AddSwaggerGenAction?.Invoke(c);
            });
        }
    }
}