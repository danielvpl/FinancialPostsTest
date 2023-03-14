using Domain.Enums;
using System;

namespace Application.Responses
{
    public class FinancialResponse
    {
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public FinancialType FinancialType { get; set; }
    }
}
