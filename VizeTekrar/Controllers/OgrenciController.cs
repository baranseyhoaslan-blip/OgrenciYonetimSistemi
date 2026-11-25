using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using VizeTekrar.Models;
namespace VizeTekrar.Controllers
{
    public class OgrenciController : Controller
    {
        VeritabaniBaglantisi vt = new VeritabaniBaglantisi();

        public IActionResult Index()
        {   var ogrencilistesi=vt.Ogrenciler.Include(x => x.Bolum).ToList();
            return View(ogrencilistesi);
        }
       
            public IActionResult Detay(int id)
            {
                var ogrenci= vt.Ogrenciler.Include(x => x.Bolum).FirstOrDefault(x => x.Id == id);
                if (ogrenci == null)
                {
                TempData["Hata"] = "Öğrenci bulunamadı.";
                return RedirectToAction("Index");
            }
                return View(ogrenci);

        }
        [HttpGet]
        public IActionResult OgrenciEkle()
        {
           
            ViewData["BolumlerId"] = new SelectList(vt.Bolumler, "Id", "BolumAdi");

            return View(new Ogrenciler());
        }
        [HttpPost]
        public async Task<IActionResult> OgrenciEkle(Ogrenciler model) {
            vt.Ogrenciler.Add(model);
            await vt.SaveChangesAsync();
            return RedirectToAction("Index", "Ogrenci");
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var ogrenci = vt.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.BolumListesi = new SelectList(vt.Bolumler.ToList(), "BolumlerId", "BolumAdi", ogrenci.BolumlerId);
            return View(ogrenci);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.BolumListesi = new SelectList(vt.Bolumler.ToList(), "BolumlerId", "BolumAd");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
            public IActionResult Ekle(Ogrenciler model, IFormFile? ResimURL)
        {
            ModelState.Remove("Bolum");
            ModelState.Remove("Fotograf");
            if (ModelState.IsValid)
            {
                if (ResimURL != null && ResimURL.Length > 0)
                {
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);
                    string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
                    if (allowedExtensions.Contains(imginfo.Extension.ToLower()))
                    {
                        string yeniResimAdi = Guid.NewGuid().ToString() + imginfo.Extension;
                        string yuklemeKlasoru = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot/Uploads/Ogrenciler");
                        if (!Directory.Exists(yuklemeKlasoru))
                        {
                            Directory.CreateDirectory(yuklemeKlasoru);
                        }
                        string tamYol = Path.Combine(yuklemeKlasoru, yeniResimAdi);
                        using (var stream = new FileStream(tamYol, FileMode.Create))
                        {
                            ResimURL.CopyTo(stream);
                        }
                        model.FotografYolu = "/Uploads/Ogrenciler/" + yeniResimAdi;
                    }
                }
                 
                vt.Ogrenciler.Add(model);
                vt.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumListesi = new SelectList(vt.Bolumler.ToList(), "BolumlerId", "BolumAd", model.BolumlerId);
            return View(model); }


            [HttpPost]
            [ValidateAntiForgeryToken]
            
            public IActionResult Sil(int id)
            {
                var ogrenci = vt.Ogrenciler.Find(id);
                if (ogrenci != null)
                {
                    if (!string.IsNullOrEmpty(ogrenci.FotografYolu))
                    {
                        string dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                       ogrenci.FotografYolu.TrimStart('/'));
                        if (System.IO.File.Exists(dosyaYolu))
                        {
                            System.IO.File.Delete(dosyaYolu);
                        }
                    }
                    vt.Ogrenciler.Remove(ogrenci);
                    vt.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        

        public IActionResult OgrenciBul(int id) 
        {
            var ogrenci = vt.Ogrenciler.Find(id);
            if (ogrenci == null) 
                return RedirectToAction("Index");
            return View(ogrenci);
        }
        public IActionResult IDGetir(int id)
        {
            var ogrenci = vt.Ogrenciler.Find(id);
            if (ogrenci == null) 
                return RedirectToAction("Index");
            ViewBag.BolumListesi = new SelectList(vt.Bolumler.ToList(), "BolumlerId", "BolumAd",ogrenci.BolumlerId);
            return View(ogrenci);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(Ogrenciler model, IFormFile? ResimURL)
        {
            ModelState.Remove("Bolum");
            ModelState.Remove("Fotograf");
            if (ModelState.IsValid)
            {
                var mevcutOgrenci = vt.Ogrenciler.Find(model.Id);
                if (mevcutOgrenci != null)
                {
                    
                    mevcutOgrenci.Ad = model.Ad;
                    mevcutOgrenci.Soyad = model.Soyad;
                    mevcutOgrenci.Cinsiyet = model.Cinsiyet;
                    mevcutOgrenci.DogumTarihi = model.DogumTarihi;
                    mevcutOgrenci.Eposta = model.Eposta;
                    mevcutOgrenci.Telefon = model.Telefon;
                    mevcutOgrenci.BolumlerId = model.BolumlerId;
                    if (ResimURL != null && ResimURL.Length > 0)
                    {
                        FileInfo imginfo = new FileInfo(ResimURL.FileName);
                        string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
                        if (allowedExtensions.Contains(imginfo.Extension.ToLower()))
                        {
                            if (!string.IsNullOrEmpty(mevcutOgrenci.FotografYolu))
                            {
                                string eskiYol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                               mevcutOgrenci.FotografYolu.TrimStart('/'));
                                if (System.IO.File.Exists(eskiYol))
                                {
                                    System.IO.File.Delete(eskiYol);
                                }
                            }
                            string yeniResimAdi = Guid.NewGuid().ToString() + imginfo.Extension;
                            string yuklemeKlasoru = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot/Uploads/Ogrenciler");
                            if (!Directory.Exists(yuklemeKlasoru))
                            {
                                Directory.CreateDirectory(yuklemeKlasoru);
                            }
                            string tamYol = Path.Combine(yuklemeKlasoru, yeniResimAdi);
                            using (var stream = new FileStream(tamYol, FileMode.Create))
                            {
                                ResimURL.CopyTo(stream);
                            }
                            mevcutOgrenci.FotografYolu = "/Uploads/Ogrenciler/" + yeniResimAdi;
                        }
                    }
                    vt.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.BolumListesi = new SelectList(vt.Bolumler.ToList(), "BolumlerId", "BolumAd", model.BolumlerId);
            return View("IDGetir", model);
        }
    }
}



        

