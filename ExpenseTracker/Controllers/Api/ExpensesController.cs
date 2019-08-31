using AutoMapper;
using ExpenseTracker.Models;
using ExpenseTracker.Dtos;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace vidly.Controllers.Api
{
    public class ExpensesController : ApiController
    {
        private ApplicationDbContext _context;

        public ExpensesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/expenses
        public IHttpActionResult GetExpenses(string query = null)
        {
            var expensesQuery = _context.Expenses
                .Include(c => c.Category);

            if (!String.IsNullOrWhiteSpace(query))
                expensesQuery = expensesQuery.Where(c => c.Name.Contains(query));

            var expensesDtos = expensesQuery
                .ToList()
                .Select(Mapper.Map<Expense, ExpenseDto>);

            return Ok(expensesDtos);
        }

        // GET /api/expenses/id
        public IHttpActionResult GetExpenses(int id)
        {
            var expense = _context.Expenses
                .SingleOrDefault(c => c.Id == id);

            if (expense == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Expense, ExpenseDto>(expense));
        }

        // POST /api/expenses
        [HttpPost]
        public IHttpActionResult CreateExpense(EditExpenseDto expenseDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var expense = Mapper.Map<EditExpenseDto, Expense>(expenseDto);
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            expenseDto.Id = expense.Id;

            //return expenseDto;
            return Created(new Uri(Request.RequestUri + "/" + expense.Id), expenseDto);
        }

        // PUT /api/expenses/1
        [HttpPut]
        public void UpdateExpense(int id, EditExpenseDto expenseDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var expenseInDb = _context.Expenses.SingleOrDefault(c => c.Id == id);

            if (expenseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(expenseDto, expenseInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDb.BirthDate = customer.BirthDate;
            _context.SaveChanges();
        }
    }
}
