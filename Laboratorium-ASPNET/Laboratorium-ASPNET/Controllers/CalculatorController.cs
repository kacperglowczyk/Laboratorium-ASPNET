using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Form()
        {
            return View();
        }
        /*
        [HttpGet]
        public IActionResult Result(double x, string @operator, double y)
        {
            var model = new Calculator
            {
                X = x,
                Y = y,
                Operator = GetOperator(@operator)
            };

            if (!model.IsValid())
            {
                return View("Error");
            }

            ViewBag.Result = model.Calculate();
            return View(model);
        }
        */
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        private Operator? GetOperator(string @operator)
        {
            switch (@operator.ToUpper())
            {
                case "ADD":
                    return Operator.Add;
                case "SUB":
                    return Operator.Sub;
                case "MUL":
                    return Operator.Mul;
                case "DIV":
                    return Operator.Div;
                default:
                    return null;
            }
        }
    }
}