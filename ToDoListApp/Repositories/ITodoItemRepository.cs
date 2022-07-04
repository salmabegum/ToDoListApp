using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        void Add (TodoItem item);
        void Update (TodoItem item);
        void Delete (TodoItem item);
        void DeleteRange(IEnumerable<TodoItem> items);


    }
}
