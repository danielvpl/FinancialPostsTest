using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFinancialService
    {
        Task<bool> FinancialPost(decimal value, FinancialType type);
        Task<List<Financial>> ConsolidatedReport(DateTime date);        
    }
}
