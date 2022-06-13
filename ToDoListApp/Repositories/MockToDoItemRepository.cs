using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class MockToDoItemRepository
    {
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public TodoItem Get(int id)
        {
            return _todoItems.Where(x => x.Id == id).FirstOrDefault();            
        }

        public void Create(TodoItem model)
        {
            model.Id = new Random().Next();
            model.CreatedAt = DateTimeOffset.Now;            
            _todoItems.Add(model);
        }

        public void Update(TodoItem model)
        {           
            var OriginalItem = _todoItems.Where(x => x.Id == model.Id).FirstOrDefault();            
            OriginalItem.Text = model.Text;
            OriginalItem.IsCompleted = model.IsCompleted;
        }

        public void Delete(TodoItem item)
        {
            var Item = _todoItems.Where(x => x.Id == item.Id).FirstOrDefault();
            _todoItems.Remove(Item);            
        }

    }
}
