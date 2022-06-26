using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Contexts;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class ToDoItemRepository
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
            return  _db.TodoItems.Where(x => x.Id == id).FirstOrDefault();
       
        }

        public void Create(TodoItem model)
        {
            _db.TodoItems.Add(model);
            _db.SaveChanges();
        }

        public void Update(TodoItem model)
        {
            var item = Get(model.Id);
            item.Text = model.Text;
            item.Price = model.Price;
            item.IsCompleted = model.IsCompleted;
            _db.SaveChanges();
        }

        public void Delete(TodoItem model)
        {
            var item = Get(model.Id);
            _db.TodoItems.Remove(item);
            _db.SaveChanges();
        }
    }
}
