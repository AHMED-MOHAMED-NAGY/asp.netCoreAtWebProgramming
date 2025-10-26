using Microsoft.AspNetCore.Mvc;

namespace H3C2.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult ogrEkle()
        {
            TempData["Ad"] = "Mehmet => Temp data";
            ViewData["no"] = 10;
            ViewBag.msj = "ViewBag";
            return View();
        }
        public IActionResult Deneme1()
        {
            TempData["Ad"] = "Mehmet => Temp data";
            ViewData["no"] = 10;
            ViewBag.msj = "ViewBag";
            return RedirectToAction("Deneme2");
        }
        public IActionResult Deneme2() 
        {
            if (TempData["Ad"] is not null)
            {
                string ad = TempData["Ad"].ToString();
            }
            return View();
        }
    }
}
