using Microsoft.AspNetCore.Mvc;

namespace CW21.Controllers
{
    public class DashboredController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
