using Microsoft.AspNetCore.Mvc;

namespace CIS_341_Lab06.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
