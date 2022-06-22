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
            throw new NotImplementedException();
        }

        public void Create(TodoItem model)
        {
            _db.TodoItems.Add(model);
        }

        public void Update(TodoItem model)
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
