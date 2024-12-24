using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_ASPNET.Controllers
{
    public class ComputerController : Controller
    {
        private static Dictionary<int, Computer> _computers = new();

        public IActionResult Index()
        {
            return View(_computers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Computer model)
        {
            if (ModelState.IsValid)
            {
                int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() + 1 : 1;
                model.Id = id;
                _computers.Add(model.Id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computers[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_computers.ContainsKey(id))
            {
                _computers.Remove(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }
    }
}
