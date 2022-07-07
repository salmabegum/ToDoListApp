using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public interface ITodoItemRepository
    {
        IEnumerable<GroceryItem> GetAll();
        GroceryItem Get(int id);
        void Add (GroceryItem item);
        void Update (GroceryItem item);
        void Delete (GroceryItem item);
        void DeleteRange(IEnumerable<GroceryItem> items);


    }
}
