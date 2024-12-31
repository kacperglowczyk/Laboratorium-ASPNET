using Microsoft.AspNetCore.Mvc;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Controllers;

    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        public IActionResult Index()
        {
            return View(_computerService.FindAll());
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
                _computerService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var computer = _computerService.FindById(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computerService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var computer = _computerService.FindById(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var computer = _computerService.FindById(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _computerService.Delete(id);
            return RedirectToAction("Index");
        }
    }

