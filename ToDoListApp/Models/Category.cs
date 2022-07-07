using System;
using System.Collections.Generic;

namespace ToDoListApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public List<GroceryItem> GroceryItems { get; set; }
    }
}
