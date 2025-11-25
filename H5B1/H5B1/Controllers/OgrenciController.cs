using H5B1.Models;
using Microsoft.AspNetCore.Mvc;

namespace H5B1.Controllers
{
    public class OgrenciController : Controller
    {
        public static List<Ogrenci> ogrenciler = new List<Ogrenci>(); // data gimemsi icin 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OgrEkle() 
        {
            return View();
        }
        public IActionResult OgrEkleOto() { 
            return View();
        }
        public IActionResult OgrKaydet(Ogrenci ogr) {
            
            if (ModelState.IsValid) { //parametre olarak modelim tum kisitleri sagliyorsa true
                // hata yok
                // save to DB
                ogrenciler.Add(ogr);
                TempData["msj"] = ogr.OgrAd + " adli ogrenci eklendi"; // to print DONE msj
                return RedirectToAction("OgrList"); // giris sayfasi 
            }
            TempData["hata"] = "lutfen tum ogrenci dogru yazi";
            return RedirectToAction("OgrHata");
        }
        public IActionResult OgrList()
        {
            return View(ogrenciler);
        }

        public IActionResult test() 
        {
            return View();
        }

        public IActionResult OgrHata() {
            return View();
        }
    }
}
