using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class InvestmentTdsServiceCalculateInvestment
    {
        private readonly FinancialService _service;
        private readonly Mock<IFinancialRepository> _repo;
        private readonly Mock<IMemoryCache> _cache;
        private readonly List<Financial> _financialPosts;

        public InvestmentTdsServiceCalculateInvestment()
        {
            _repo = new Mock<IFinancialRepository>();
            _cache = new Mock<IMemoryCache>();
            _service = new FinancialService(_repo.Object, _cache.Object);
            _financialPosts = new List<Financial>()
            {
                new Financial(){
                    Value = 829.69m,
                    DateCreated = DateTime.Parse("2023-03-13T12:10:00"),
                    FinancialType = Enums.FinancialType.Credit
                },
                new Financial(){
                    Value = 127.57m,
                    DateCreated = DateTime.Parse("2023-03-13T12:20:00"),
                    FinancialType = Enums.FinancialType.Credit
                },
                new Financial(){
                    Value = 621.69m,
                    DateCreated = DateTime.Parse("2023-03-13T12:30:00"),
                    FinancialType = Enums.FinancialType.Debit
                }
            };          
        }

        [Fact]
        public async void ShouldReturnConsolidatedFinancialPosts()
        {
            var dt = DateTime.Parse("13/03/2023");

            _repo.Setup(x => x.GetFinancialPosts(null)).ReturnsAsync(_financialPosts);           

            var result = await _service.ConsolidatedReport(dt);

            Assert.NotNull(result);
            Assert.IsType<List<Financial>>(result);            
        }
    }
}
