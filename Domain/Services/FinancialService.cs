using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly IFinancialRepository _repository;
        
        public FinancialService(IFinancialRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Financial>> ConsolidatedReport(DateTime date)
        {
            return await _repository.GetFinancialPosts(date.Date);                
        }

        public async Task<bool> FinancialPost(decimal value, FinancialType type)
        {
            return await _repository.FinancialPost(new Financial()
            {
                Value = value,
                FinancialType = type,
                DateCreated = DateTime.Now
            });
        }
    }
}
