using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly IFinancialRepository _repository;
        private readonly IMemoryCache _cache;

        public FinancialService(IFinancialRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<Financial>> ConsolidatedReport(DateTime date)
        {
            var cacheEntry = await _cache.GetOrCreateAsync("ResultCache", entry =>
            {
                if (entry != null)
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                    entry.SetPriority(CacheItemPriority.High);
                }
                return _repository.GetFinancialPosts(date.Date);                
            });
            return cacheEntry;
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
