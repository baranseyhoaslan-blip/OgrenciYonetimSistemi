using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using VizeTekrar.Models;

namespace VizeTekrar.Controllers
{
    public class BolumlerController : Controller
    {
        VeritabaniBaglantisi veri = new VeritabaniBaglantisi();
        public IActionResult Index()
        {
            var bolumler = veri.Bolumler.ToList();
            return View(bolumler);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BolumEkle(Bolumler bolum)
        {
            if (ModelState.IsValid)
            {
                veri.Bolumler.Add(bolum);
                veri.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum);
        }
        [HttpPost]
        public IActionResult Sil(int id)
        {
            var bolum = veri.Bolumler.Find(id);
            if (bolum != null)
            {
                veri.Bolumler.Remove(bolum);
                veri.SaveChanges();
            }
            return RedirectToAction("Index");


        }
    }
}
