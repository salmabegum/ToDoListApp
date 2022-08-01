using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Contexts;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class ToDoItemRepository : IRepository<GroceryItem>
    {
        private readonly ApplicationDbContext _db;
        public ToDoItemRepository(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IEnumerable<GroceryItem> GetAll()
        {
            return _db.GroceryItems.Include(x => x.Category);
        }


        public GroceryItem Get(int id)
        {
        return _db .GroceryItems.FirstOrDefault(x => x.Id == id);
        }
     
        public void Add(GroceryItem model)
        {
                model.CreatedAt = DateTimeOffset.UtcNow;
            model.CategoryId = model.CategoryId;
            model.TotalPrice = model.Price * model.Qty;
            _db.GroceryItems.Add(model);
            _db.SaveChanges();
        }

        public void Update(GroceryItem model)
        {
            var originalItem = Get(model.Id);
            originalItem.Text = model.Text;
            originalItem.IsCompleted = model.IsCompleted;
            originalItem.Qty  = model.Qty;
            originalItem.Price = model.Price;
            originalItem.TotalPrice = model.Qty* model.Price;

            originalItem.Category = model.Category;
       
            _db.SaveChanges();
        }

        public void Delete(GroceryItem item)
        {
           _db.GroceryItems.Remove(item);
            _db.SaveChanges();
        }
        public void DeleteRange(IEnumerable<GroceryItem> items)
        {
            _db.GroceryItems.RemoveRange(items);
            _db.SaveChanges();
        }


    }
}
