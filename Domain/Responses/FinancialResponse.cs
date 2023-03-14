using Domain.Enums;
using System;

namespace Domain.CustomResponse
{
    public class FinancialResponse
    {
        public double Valor { get; set; }
        public DateTime DateCreated { get; set; }
        public FinancialType FinancialType { get; set; }
    }
}
