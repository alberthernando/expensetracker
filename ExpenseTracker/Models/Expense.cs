using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public byte Quantity { get; set; }
        
        public string UnitOfMeasure { get; set; }

        [Required]
        public int UnitPrice { get; set; }

    }
}