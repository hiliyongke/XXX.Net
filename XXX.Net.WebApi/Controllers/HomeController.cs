// ──────────────────────────────────────────────────────────────
// 　文   件：HomeController.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 9:20
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

#region

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XXX.Net.WebApi.Models;

#endregion

namespace XXX.Net.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}