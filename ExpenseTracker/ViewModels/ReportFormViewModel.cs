using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels
{
    public class ReportFormViewModel
    {
        public DateTime BeginDate;
        public DateTime EndDate;

        public List<byte> CategoryIds { get; set; }
    }
}

