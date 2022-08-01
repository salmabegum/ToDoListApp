using Microsoft.AspNetCore.Mvc;
using System;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace ToDoListApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryStore;

        public CategoryController(IRepository<Category> categoryStore)
        {
            _categoryStore = categoryStore;
        }

        public IActionResult Index()
        {
            return View(_categoryStore.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Create(Category model)
        {
            var category = new Category
            {
                Name = model.Name,
                CreatedAt = DateTimeOffset.UtcNow
            };
            _categoryStore.Add(category);
         
            return RedirectToAction("Index", "Category");
            
        }

        public IActionResult Delete(int id)
        {
            var item = _categoryStore.Get(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id {id} was not found";
                return View("NotFound");
            }

            _categoryStore.Delete(item);

            return RedirectToAction("Index", "Category");
        }


    }
}
