using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FinancialApp : IFinancialApp
    {
        private readonly IFinancialService _service;
        private readonly IMapper _mapper;

        public FinancialApp(IFinancialService financialService,
            IMapper mapper)
        {
            _service = financialService;
            _mapper = mapper;
        }

        public async Task<FinancialConsolidatedResponse> GetFinancialConsolidated(DateTime date)
        {
            try
            {
                var financials = await _service.ConsolidatedReport(date);

                var consolidatedResult = new FinancialConsolidatedResponse()
                {
                    currentData = date,
                    financialPosts = _mapper.Map<List<FinancialResponse>>(financials)
                };

                return consolidatedResult;

            }catch(Exception)
            {
                throw;                      
            }
        }

        public async Task<bool> FinancialPost(decimal value, FinancialType type)
        {
            try
            {
                return await _service.FinancialPost(value, type);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
