using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            return View(model);
        }
    }
}