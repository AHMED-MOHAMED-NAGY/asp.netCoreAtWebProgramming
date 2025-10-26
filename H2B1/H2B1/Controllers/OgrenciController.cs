using H2B1.Models;
using Microsoft.AspNetCore.Mvc;

namespace H2B1.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String OgrEkle() {
            return "Ekle Ogrenci ";
        }

        public IActionResult OgrGoster() {

            Ogrenci o = new Ogrenci();
            o.ogrName = "i";
            return View();
        }
    }
}
