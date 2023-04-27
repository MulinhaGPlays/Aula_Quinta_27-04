using Aula_Quinta.D_ata_A_ccess_L_ayer;
using Aula_Quinta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula_Quinta.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL_Cursos _cursosContext;
        public HomeController(DAL_Cursos cursosContext)
        {
            _cursosContext = cursosContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _cursosContext.Preparar_Cursos();
            return View(_cursosContext.Pegar_Cursos());
        }

        [HttpPost]
        public IActionResult Curso(string pesquisa)
        {
            var curso = _cursosContext.Pegar_Curso(pesquisa);
            return curso is null ? RedirectToAction(nameof(Index)) : View(curso);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}