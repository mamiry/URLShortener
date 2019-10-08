using Microsoft.AspNetCore.Mvc;
using URLShortener.Core.Converter;
using URLShortener.Core.Utilities;

namespace URLShortener.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                ViewBag.UrlShort = StaticValues.SiteURL + TextHelper.ToShortUrl(5, url);
            }
            return View();
        }
    }
}
