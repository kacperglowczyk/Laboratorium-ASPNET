using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_ASPNET.Controllers
{
    public class ComputerController : Controller
    {
        // Static collection to store computer objects
        private static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();

        // Index: List all computers
        public IActionResult Index()
        {
            return View(_computers);
        }

        // GET: Create new computer form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Save new computer
        [HttpPost]
        public IActionResult Create(Computer model)
        {
            if (ModelState.IsValid)
            {
                // Generate new unique ID
                int id = _computers.Keys.Count > 0 ? _computers.Keys.Max() + 1 : 1;
                model.Id = id;

                // Add to collection
                _computers.Add(model.Id, model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Edit computer form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }

        // POST: Update computer
        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (ModelState.IsValid)
            {
                // Update computer in collection
                _computers[model.Id] = model;

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Details of a specific computer
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }

        // GET: Confirm delete computer
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_computers.ContainsKey(id))
            {
                return View(_computers[id]);
            }
            return NotFound();
        }

        // POST: Delete computer
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_computers.ContainsKey(id))
            {
                _computers.Remove(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
