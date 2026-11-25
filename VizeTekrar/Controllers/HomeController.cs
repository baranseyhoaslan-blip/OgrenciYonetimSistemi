using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VizeTekrar.Models;

namespace VizeTekrar.Controllers
{
    public class HomeController : Controller
    {
        VeritabaniBaglantisi vt = new VeritabaniBaglantisi();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ToplamBolum = vt.Bolumler.Count();
            ViewBag.ToplamOgrenci = vt.Ogrenciler.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
