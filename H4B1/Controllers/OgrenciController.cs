using H4B1.Models;
using Microsoft.AspNetCore.Mvc;

namespace H4B1.Controllers
{
    public class OgrenciController : Controller
    {
        public static List<Ogrenci> ogrenciler = new List<Ogrenci>(); // reset yada refreach yapildiginda hersey gider bir request 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ogrEkle()
        {
            return View();
        }

        //[HttpGet] varsa mantikli degil cunku defualt olarak get ile calisir

        // for get
        //public string ogrKaydet() {
        //    string ad = HttpContext.Request.Query["ogrAd"];
        //    string soyad = HttpContext.Request.Query["ogrSoyad"];
        //    string no = HttpContext.Request.Query["ogrNo"];
        //    return ad+ " " + soyad + " "+ no;
        //}

        [HttpPost] // http post varsa calissin
        public string ogrKaydet() {
            string ad = HttpContext.Request.Form["ogrAd"];
            string soyad = HttpContext.Request.Form["ogrSoyad"];
            string no = HttpContext.Request.Form["ogrNo"];

            // data temizleme 
            // DB kayet
            return ad + " " + soyad + " " + no;
        }

        public string OgrKaydetParams(string ogrAdi, string ogrSoyad, string ogrNo){
            string ad = ogrAdi;
            string soyad = ogrSoyad;
            string no = ogrNo;
            return ad + " " + soyad +" "+ no;
        }

        public string OgrKaydetClass(Ogrenci ogr) 
        {
            string ad = ogr.ogrAdi;
            string soyad = ogr.ogrSoyad;
            string no = ogr.ogrNo;
            return ad + " " + soyad +" "+ no;
        }

        public IActionResult OgrKaydetClassView(Ogrenci ogr) 
        {
            string ad = ogr.ogrAdi;
            string soyad = ogr.ogrSoyad;
            string no = ogr.ogrNo;
            if (string.IsNullOrEmpty(ad)) {
                TempData["Hata"] = "name is null or empty";
                return RedirectToAction("ogrHata");
            }
            return View(ogr);
        }
        public IActionResult OgrKaydetClassViewAll(Ogrenci ogr) {
            ogrenciler.Add(ogr);
            TempData["msj"] = ogr.ogrAdi + " adli ogrenci eklendi";
            return RedirectToAction("OgrList");
        }
        public IActionResult OgrList() {
            return View(ogrenciler);
        }
        public IActionResult ogrHata()
        {
            return View();
        }
    }
}
