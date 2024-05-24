
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace leman_exam.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}
