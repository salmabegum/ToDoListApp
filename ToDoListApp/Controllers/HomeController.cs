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
        private readonly IRepository<GroceryItem> _groceryStore;
        private readonly IRepository<Category> _categoryStore;

        public HomeController(ILogger<HomeController> logger, IRepository<GroceryItem> groceryStore, IRepository<Category> categoryStore)
        {
            _logger = logger;
            _groceryStore = groceryStore;
            _categoryStore = categoryStore;

        }

        public IActionResult Index()
        {            
            return View(_groceryStore.GetAll());
        }
        public IActionResult Search(string searchTerm)
        {
            var items = _groceryStore.GetAll();

            if (searchTerm == null)
            {
                return View("Index", items);
            }

            var lowerCaseSearchTerm = searchTerm.ToLower();

            var filteredItems = items.Where(x =>
                x.Text.ToLower().Contains(lowerCaseSearchTerm)
                || x.Category.Name.ToLower().Contains(lowerCaseSearchTerm));

            return View("Index", filteredItems);
        }
        public IActionResult Sort(string sortBy, string orderBy)
        {
            var items = _groceryStore.GetAll();

            if (sortBy == "CreatedAt")
            {

                if (orderBy == "Asc")
                {
                    items = items.OrderBy(x => x.CreatedAt);
                }
                else if (orderBy == "Desc")
                {
                    items = items.OrderByDescending(x => x.CreatedAt);
                }
            }
            else if (sortBy == "Price")
            {

                if (orderBy == "Asc")
                {
                    items = items.OrderBy(x => x.Price);
                }
                else if (orderBy == "Desc")
                {
                    
                    items = items.OrderByDescending(x => x.Price);
                }
            }
            else if (sortBy == "Total Price")
            {

                if (orderBy == "Asc")
                {
                    items = items.OrderBy(x => x.TotalPrice);
                }
                else if (orderBy == "Desc")
                {

                    items = items.OrderByDescending(x => x.TotalPrice);
                }
            }

            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryStore.GetAll();
            return View();

        }

        [HttpPost]
        public IActionResult Create(GroceryItem model)
        
        {
            _groceryStore.Add(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _groceryStore.Get(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id {id} was not found";
                return View("NotFound");
            }

            ViewBag.Categories = _categoryStore.GetAll();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(GroceryItem model)
        {
            _groceryStore.Update(model);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _groceryStore.Get(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id {id} was not found";
                return View("NotFound");
            }

            _groceryStore.Delete(item);

            return RedirectToAction("Index", "Home");
        }
    
       
        public IActionResult Delete(GroceryItem model)
        {
            _groceryStore.Delete(model);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteAll()
        {
            var items = _groceryStore.GetAll();

            /*foreach (var item in items)
            {
                _todoItemStore.Delete(item);
            }*/

            _groceryStore.DeleteRange(items);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy", _groceryStore.GetAll());
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      