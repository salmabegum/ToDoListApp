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
         
        [Required]
         public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCopmpleted { get; set; }


    }
}
