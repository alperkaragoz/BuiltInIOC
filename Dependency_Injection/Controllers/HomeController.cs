using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log;
        public HomeController(ILog log)
        {
            _log = log;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
