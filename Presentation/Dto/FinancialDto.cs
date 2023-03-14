using Domain.Enums;

namespace FinancialApi.Dto
{
    public class FinancialDto
    {
        public decimal value { get; set; }
        public FinancialType financialType { get; set; }
    }
}
