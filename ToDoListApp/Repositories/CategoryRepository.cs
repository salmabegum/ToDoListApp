using System;
using System.Collections.Generic;
using ToDoListApp.Contexts;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    { 
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }  

        public void Add(Category item)
        {

          
            _db.Category.Add(item);
            _db.SaveChanges();
          
        }

        public void Delete(Category item)
        {
            _db.Category.Remove(item);
            _db.SaveChanges();

        }

        public void DeleteRange(IEnumerable<Category> items)
        {
            throw new System.NotImplementedException();
        }


        public Category Get(int id)
        {
            return _db.Category.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category;
        }

        public void Update(Category item)
        {
            throw new System.NotImplementedException();
        }

      
    }

    
}
