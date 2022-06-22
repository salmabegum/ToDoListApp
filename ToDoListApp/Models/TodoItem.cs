using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class TodoItem
    {
        
        public int Id { get; set;  }
         
        [Required(ErrorMessage ="Text must NOT be empty")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Text must be at least 3 characters but no more than 10 characters")]
        public string Text { get; set; }
        public decimal Price { get; set; }

        public string PriceString
        {
            get
            {
                return $"${ Price }";
            }
        }
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCompleted { get; set; }        
      
    }
}
