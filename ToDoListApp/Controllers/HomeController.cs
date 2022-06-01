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
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var item = new TodoItem
            {
                Id = 1,
                Text = "Programming",
                CreatedAt = DateTimeOffset.UtcNow,
                IsCopmpleted = false
            };
            _todoItems.Add(item);
            return View("Index",_todoItems);
        }

        public IActionResult Create()
        {
            return View("Create");
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
