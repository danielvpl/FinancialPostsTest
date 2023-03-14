using Application.Responses;
using Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFinancialApp
    {
        Task<bool> FinancialPost(decimal value, FinancialType type);
        Task<FinancialConsolidatedResponse> GetFinancialConsolidated(DateTime date);
    }
}
