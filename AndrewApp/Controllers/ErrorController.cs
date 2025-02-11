using Microsoft.AspNetCore.Mvc;

namespace AndrewApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage404()
        {
            return View();
        }
    }
}
