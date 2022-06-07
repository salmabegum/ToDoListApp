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
        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public void Create(TodoItem model)
        {
            model.Id = new Random().Next();
            model.CreatedAt = DateTimeOffset.Now;            
            _todoItems.Add(model);
        }

        public void Edit(TodoItem model)
        {
            TodoItem OriginalItem = _todoItems.Where(x => x.Id == model.Id).FirstOrDefault();
            var NewItem = OriginalItem;
            NewItem.Text = model.Text;
            NewItem.IsCompleted = model.IsCompleted;
            int position = _todoItems.IndexOf(OriginalItem);
            _todoItems[position] = NewItem;
        }

        public void Delete(TodoItem model)
        {
            var Item = _todoItems.Where(x => x.Id == model.Id).FirstOrDefault();
            _todoItems.Remove(Item);
            
        }

    }
}
