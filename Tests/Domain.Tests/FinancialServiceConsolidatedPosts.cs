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
    public class FinancialAppGetConsolidatedPosts
    {
        private readonly FinancialService _service;
        private readonly Mock<IFinancialRepository> _repo;
        private readonly List<Financial> _financialPosts;

        public FinancialAppGetConsolidatedPosts()
        {
            _repo = new Mock<IFinancialRepository>();
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
            var memoryCache = MockMemoryCacheService.GetMemoryCache(_financialPosts);
            _service = new FinancialService(_repo.Object, memoryCache);
        }

        [Fact]
        public async void ShouldReturnConsolidatedFinancialPosts()
        {
            var dt = new DateTime(2023, 3, 13);

            _repo.Setup(x => x.GetFinancialPosts(dt.Date)).ReturnsAsync(_financialPosts);

            var result = await _service.ConsolidatedReport(dt);
            
            Assert.NotNull(result);
            Assert.IsType<List<Financial>>(result);            
        }

        public static class MockMemoryCacheService
        {
            public static IMemoryCache GetMemoryCache(object expectedValue)
            {
                var mockMemoryCache = new Mock<IMemoryCache>();
                mockMemoryCache
                    .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
                    .Returns(true);
                return mockMemoryCache.Object;
            }
        }
    }
}
