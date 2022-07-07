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
        private readonly ITodoItemRepository _todoItemStore;


        public HomeController(ILogger<HomeController> logger, ITodoItemRepository todoItemStore)
        {
            _logger = logger;
            _todoItemStore = todoItemStore;            
        }

        public IActionResult Index()
        {            
            return View(_todoItemStore.GetAll());
        }
        public IActionResult Search(string searchTerm)
        {
            var items = _todoItemStore.GetAll();
            var filteredItems = items.Where(x => x.Text.ToLower().Contains(searchTerm.ToLower()));
            if (searchTerm == null)
          { 
             
                return View("Index", items);
            }

            return View("Index", filteredItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        } 

        [HttpPost]
        public IActionResult Create(GroceryItem model)
        {
            _todoItemStore.Add(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GroceryItem item = _todoItemStore.GetAll().Where(t=> t.Id==id).FirstOrDefault();
            return View(item);
            
        }

        [HttpPost]
        public IActionResult Edit(GroceryItem model)
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
        public IActionResult Delete(GroceryItem model)
        {
            _todoItemStore.Delete(model);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteAll()
        {
            var items = _todoItemStore.GetAll();
            //foreach (var item in items)
            //{
            //    _todoItemStore.Delete(item);
            //}
            _todoItemStore.DeleteRange(items);

            return RedirectToAction("Index" );
        }

        public IActionResult Privacy()
        {
            return View("Privacy", _todoItemStore.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      