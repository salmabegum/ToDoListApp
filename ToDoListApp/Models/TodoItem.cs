using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.Models
{
    public class GroceryItem
    {
        
        public int Id { get; set;  }
        public int CategoryId { get; set;  } 

        [Required(ErrorMessage ="Text must NOT be empty")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Text must be at least 3 characters but no more than 10 characters")]
        public string Text { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }


        

        public int Qty { get; set; }

        [NotMapped]
        public string PriceString
        {
            get
            {
                return $"${ Price }";
            }
        }
        public DateTimeOffset CreatedAt { get; set; }
        [NotMapped]
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy");
            }
        }

         
        public bool IsCompleted { get; set; }
        //Navigation Property
        public virtual  Category Category { get; set; }

    }
}
