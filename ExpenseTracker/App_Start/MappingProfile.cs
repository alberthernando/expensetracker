using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ExpenseTracker.Models;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Expense, ExpenseDto>();
            Mapper.CreateMap<ExpenseDto, Expense>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Expense, EditExpenseDto>();
            Mapper.CreateMap<EditExpenseDto, Expense>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
