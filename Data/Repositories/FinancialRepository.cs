using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FinancialRepository : IFinancialRepository
    {
        private readonly ContextApp _context;
        private readonly ILogger<FinancialRepository> _logger;
        private readonly IMemoryCache _cache;

        public FinancialRepository(ContextApp context, IMemoryCache cache)
        {
            var loggerFactory = new LoggerFactory();
            ILogger<FinancialRepository> logger = loggerFactory.CreateLogger<FinancialRepository>();
            _logger = logger;            
            _context = context;
            _cache = cache;
        }

        public async Task<bool> FinancialPost(Financial financial)
        {
            try
            {
                await _context.Financials.AddAsync(financial);
                await _context.SaveChangesAsync();                
                _logger.LogInformation("Financial Post Created");
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false; 
            };
        }

        public async Task<List<Financial>> GetFinancialPosts(DateTime? date = null)
        {
            DateTime dt = date != null ? date.Value.Date : new DateTime();
            var cacheEntry = await _cache.GetOrCreateAsync("ResultCache", 
                async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                    entry.SetPriority(CacheItemPriority.High);
                    return await _context.Financials
                                .Where(f => (date == null || f.DateCreated.Date == dt.Date))
                                .ToListAsync(); 
                });
            
            return cacheEntry;
        }
    }
}
