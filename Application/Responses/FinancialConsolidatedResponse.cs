using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Responses
{
    public class FinancialConsolidatedResponse
    {
        public DateTime currentData { get; set; }
        public decimal totalCredit {
            get { return financialPosts.Where(x => x.FinancialType == Domain.Enums.FinancialType.Credit).Sum(x => x.Value); }
        }
        public decimal totalDebit {
            get { return financialPosts.Where(x => x.FinancialType == Domain.Enums.FinancialType.Debit).Sum(x => x.Value); }
        }
        public decimal total
        {
            get { return totalCredit - totalDebit; }
        }
        public List<FinancialResponse> financialPosts { get; set; }        
    }
}
