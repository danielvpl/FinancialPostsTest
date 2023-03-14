using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Financial
    {
        [Key]
        public int Codigo { get; set; }
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public FinancialType FinancialType { get; set; }
    }
}
