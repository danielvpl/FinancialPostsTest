using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFinancialRepository
    {
        Task<bool> FinancialPost(Financial financial);
        Task<List<Financial>> GetFinancialPosts(DateTime? date = null);              
    }
}
