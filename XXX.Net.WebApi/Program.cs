// ──────────────────────────────────────────────────────────────
// 　文   件：Program.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 9:20
// 　更新时间：2020 04 14 12:15
// ──────────────────────────────────────────────────────────────

#region

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#endregion

namespace XXX.Net.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}