using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Interfaces;
using Laboratorium_ASPNET.Models;
using Laboratorium_ASPNET.Interfaces;


namespace Laboratorium_ASPNET.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        var contacts = _contactService.FindAll();
        return View(contacts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new Contact
        {
            Organizations = _contactService.FindAllOrganizations()
                .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Title })
                .ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Contact model)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(model);
            return RedirectToAction("Index");
        }

        model.Organizations = _contactService.FindAllOrganizations()
            .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Title })
            .ToList();

        return View(model);
    }
}