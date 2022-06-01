using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            return View(_todoItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        } 

        [HttpPost]
        public IActionResult Create(TodoItem model)
        {
            TodoItem item = new TodoItem()
            {
            Id = new Random().Next(),
            Text = model.Text,
            CreatedAt = DateTimeOffset.Now,
            IsCompleted = model.IsCompleted
            };                 
            
            _todoItems.Add(item);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int todoitemId)
        {
            TodoItem item = _todoItems.Where(t=> t.Id==todoitemId).FirstOrDefault();
            return View(item);
            
        }
        public IActionResult Privacy()
        {
            return View("Index",_todoItems);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
