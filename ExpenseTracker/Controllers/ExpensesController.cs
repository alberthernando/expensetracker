using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private ApplicationDbContext _context;

        public ExpensesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Expenses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new ExpenseFormViewModel
            {
                Expense = new Expense(),
                Categories = (IEnumerable<Models.Category>)categories,
                PageTitle = "New Expense"
            };
            viewModel.Expense.UnitPrice = null;
            viewModel.Expense.Quantity = null;
            viewModel.Expense.DateAdded = DateTime.Now;
            viewModel.Expense.ExpenseDate = DateTime.Now;
            
            return View("ExpenseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var categories = _context.Categories.ToList();
            var viewModel = new ExpenseFormViewModel
            {
                Expense = _context.Expenses.Single(c => c.Id == id),
                Categories = (IEnumerable<Models.Category>)categories,
                PageTitle = "Edit Expense"
            };

            return View("ExpenseForm", viewModel);
        }

        // GET: Expenses
        public ActionResult Save(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ExpenseFormViewModel
                {
                    Expense = expense,
                    Categories = _context.Categories.ToList()
                };
                return View("ExpenseForm", viewModel);
            }

            if (expense.Id == 0)
                _context.Expenses.Add(expense);
            else
            {
                var expenseInDb = _context.Expenses.Single(c => c.Id == expense.Id);

                //MVC tutorial example, update all properties
                //TryUpdateModel(customerInDb);

                //MVC tutorial example, update whitelist properties
                //TryUpdateModel(customerInDb, "", new string[] {"name","email"});

                expenseInDb.Name = expense.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Expenses");
        }
    }
}