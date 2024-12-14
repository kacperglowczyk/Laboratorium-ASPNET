using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public enum Operator
    {
        Add, Mul, Sub, Div, Unknown
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator op, double? a, double? b)
    {
        ViewBag.Op = op;
        ViewBag.A = a;
        ViewBag.B = b;

        if (op == null)
        {
            ViewBag.ErrorMessage("Nieprawidłowy operator");
        }
        
        if (a == null || b == null)
        {
            ViewBag.ErrorMessage("Nieprawidłowy parametr liczby");
        }

        switch (op)
        {
            case Operator.Add:
            {
                ViewBag.Result = a + b;
                break;
            }
            case Operator.Sub:
            {
                ViewBag.Result = a - b;
                break;
            }
            case Operator.Mul:
            {
                ViewBag.Result = a * b;
                break;
            }
            case Operator.Div:
            {
                if (b == 0)
                {
                    ViewBag.ErrorMessage("Dzielenie przez 0 jest niedozwolone");
                    return View("CalculatorError");
                }

                ViewBag.Result = a / b;
                break;
            }
        }
        
        return View();
    }
    
}