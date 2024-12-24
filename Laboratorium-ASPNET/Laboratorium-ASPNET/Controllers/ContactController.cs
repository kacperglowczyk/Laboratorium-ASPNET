using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, Contact> _contacts = new();

    public IActionResult Index()
    {
        return View(_contacts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contact model)
    {
        if (ModelState.IsValid)
        {
            int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() + 1 : 1;
            model.Id = id;
            _contacts.Add(model.Id, model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Contact model)
    {
        if (ModelState.IsValid)
        {
            _contacts[model.Id] = model;
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            _contacts.Remove(id);
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();
    }
}