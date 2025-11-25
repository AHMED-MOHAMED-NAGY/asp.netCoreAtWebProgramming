using System.Diagnostics;
using H7C1.Models;
using Microsoft.AspNetCore.Mvc;

namespace H7C1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static List<User> users = new List<User>()
        {
            new User(){usrName = "can" , usrPassword= "123", usrColor = "red"},
            new User(){usrName = "ali" , usrPassword= "456", usrColor = "green"},
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }
        public IActionResult LoginKontrol(User usr) 
        {
            foreach (var u in users) {
                if (usr.usrName == u.usrName && usr.usrPassword == u.usrPassword) 
                {
                    // sistemde kayitli kullanici
                    // post yardimiyla 
                    HttpContext.Session.SetString("SesUser", u.usrName);
                    //session eklemek isresem 
                    // 1 Json serialized - texte cevit ekle 
                    // 2 genirek bir tip 
                    var cookopt = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(10)
                    };
                    HttpContext.Response.Cookies.Append("CookRenk", u.usrColor, cookopt); /// sonuc gonderecegim icin response
                    return RedirectToAction("Icerik");
                    //break;
                }
            }
            TempData["msj"] = "Kullanci adi yada sifre hatali";
            return RedirectToAction("Login");
        }

        public IActionResult Icerik()
        {
            if (HttpContext.Session.GetString("SesUser") is null) {
                TempData["msj"] = "Login olunuz";
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Cikis() 
        {
            HttpContext.Session.Clear();
            TempData["msj"] = "Cikis yapildi";
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



// cookie 
// session - oturum 