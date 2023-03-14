using Application.Responses;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class InvestmentAppGetClientInvestments
    {
        private FinancialApp _app;
        private readonly Mock<IFinancialService> _service;
        private readonly Mock<IMapper> _mapper;
        private List<Financial> _financialPosts;

        public InvestmentAppGetClientInvestments()
        {
            _service = new Mock<IFinancialService>();
            _mapper = new Mock<IMapper>();

            _app = new FinancialApp(_service.Object, _mapper.Object);
            _financialPosts = new List<Financial>()
            {
                new Financial(){
                    Value = 829.69m,
                    DateCreated = DateTime.Parse("2023-03-13T12:10:00"),
                    FinancialType = FinancialType.Credit
                },
                new Financial(){
                    Value = 127.57m,
                    DateCreated = DateTime.Parse("2023-03-13T12:20:00"),
                    FinancialType = FinancialType.Credit
                },
                new Financial(){
                    Value = 621.69m,
                    DateCreated = DateTime.Parse("2023-03-13T12:30:00"),
                    FinancialType = FinancialType.Debit
                }
            };
        }

        [Fact]
        public async void ShouldReturnAverage()
        {
            var dt = DateTime.Parse("13/03/2023");

            _service.Setup(x => x.ConsolidatedReport(dt)).ReturnsAsync(_financialPosts);

            var result = await _app.GetFinancialConsolidated(dt);

            Assert.NotNull(result);
            Assert.IsType<ClientInvestments>(result);            
        }
    }
}
