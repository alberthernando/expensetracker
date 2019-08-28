using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels
{
    public class ExpenseFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Expense Expense { get; set; }

        public string PageTitle { get; set; }
    }
}

