// ����������������������������������������������������������������������������������������������������������������������������
// ����   ����Program.cs
// ����   �ߣ�YongkeLi
// ����   ����1.0
// ������ʱ�䣺2020 04 14 9:20
// ������ʱ�䣺2020 04 14 12:15
// ����������������������������������������������������������������������������������������������������������������������������

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