using Aula_Quinta.Models;
using Aula_Quinta.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula_Quinta.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string html = await HttpRequestService.ConfiguringHttp("https://www.udemy.com").GetHtml();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}