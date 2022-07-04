using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Contexts;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class ToDoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoItemRepository(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _db.TodoItems;
        }


        public TodoItem Get(int id)
        {
        return _db .TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TodoItem model)
        {
            model.CreatedAt = DateTimeOffset.Now;
            _db.TodoItems.Add(model);
            _db.SaveChanges();
        }

        public void Update(TodoItem model)
        {
            var originalItem = Get(model.Id);
            originalItem.Text = model.Text;
            originalItem.IsCompleted = model.IsCompleted;
            originalItem.Price = model.Price;
            originalItem.Category = model.Category;
            _db.SaveChanges();
        }

        public void Delete(TodoItem item)
        {
           _db.TodoItems.Remove(item);
            _db.SaveChanges();
        }
        public void DeleteRange(IEnumerable<TodoItem> items)
        {
            _db.TodoItems.RemoveRange(items);
            _db.SaveChanges();
        }


    }
}
