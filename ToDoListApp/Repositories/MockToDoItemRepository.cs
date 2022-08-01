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
        private static readonly List<GroceryItem> _todoItems = new List<GroceryItem>();

        #endregion

        #region constructor
        public MockToDoItemRepository()
        {

        }
        #endregion
        public IEnumerable<GroceryItem> GetAll()
        {
            return _todoItems;
        }


        public GroceryItem Get(int id)
        {
            return _todoItems.Where(x => x.Id == id).FirstOrDefault();            
        }

        public void Add(GroceryItem model)
        {
            model.Id = new Random().Next();
            model.CategoryId = new Random().Next();
            model.CreatedAt = DateTime.Now;
            model.Qty = model.Qty;

            _todoItems.Add(model);
        }

        public void Update(GroceryItem model)
        {           
            var OriginalItem = _todoItems.Where(x => x.Id == model.Id).FirstOrDefault();            
            OriginalItem.Text = model.Text;
            OriginalItem.IsCompleted = model.IsCompleted;
            OriginalItem.Price = model.Price;
            OriginalItem.Category = model.Category;
            OriginalItem.TotalPrice = model.TotalPrice;
            OriginalItem.Qty = model.Qty;
        }

        public void Delete(GroceryItem item)
        {
            var Item = _todoItems.Where(x => x.Id == item.Id).FirstOrDefault();
            _todoItems.Remove(item);            
        }
        public void DeleteRange(IEnumerable<GroceryItem> items)
        {

            _todoItems.RemoveRange(0, items.Count());

        }


    }
}
