using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Contexts;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoItemRepository _todoItemStore;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _todoItemStore = new ToDoItemRepository(db);            
        }

        public IActionResult Index()
        {            
            return View(_todoItemStore.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        } 

        [HttpPost]
        public IActionResult Create(TodoItem model)
        {
            _todoItemStore.Create(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TodoItem item = _todoItemStore.GetAll().Where(t=> t.Id==id).FirstOrDefault();
            return View(item);
            
        }

        [HttpPost]
        public IActionResult Edit(TodoItem model)
        {
            _todoItemStore.Update(model);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //linq 
            var delitem = _todoItemStore.GetAll().Where(x => x.Id ==id).FirstOrDefault();
            return View(delitem);
        }
        [HttpPost]
        public IActionResult Delete(TodoItem model)
        {
            _todoItemStore.Delete(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View("Index", _todoItemStore.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      