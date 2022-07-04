using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Contexts;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class MockToDoItemRepository : ITodoItemRepository
    {
        #region properties
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();

        #endregion

        #region constructor
        public MockToDoItemRepository()
        {

        }
        #endregion
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems;
        }


        public TodoItem Get(int id)
        {
            return _todoItems.Where(x => x.Id == id).FirstOrDefault();            
        }

        public void Add(TodoItem model)
        {
            model.Id = new Random().Next();
            model.CreatedAt = DateTime.Now;
            model.Category = model.Category; 
     
            _todoItems.Add(model);
        }

        public void Update(TodoItem model)
        {           
            var OriginalItem = _todoItems.Where(x => x.Id == model.Id).FirstOrDefault();            
            OriginalItem.Text = model.Text;
            OriginalItem.IsCompleted = model.IsCompleted;
            OriginalItem.Price = model.Price;
            OriginalItem.Category = model.Category;
        }

        public void Delete(TodoItem item)
        {
            var Item = _todoItems.Where(x => x.Id == item.Id).FirstOrDefault();
            _todoItems.Remove(item);            
        }
        public void DeleteRange(IEnumerable<TodoItem> items)
        {

            _todoItems.RemoveRange(0, items.Count());

        }


    }
}
