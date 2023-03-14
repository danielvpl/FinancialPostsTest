using Application.Interfaces;
using Application.Responses;
using FinancialApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IFinancialApp _app;
      
        public FinancialController(IFinancialApp app)
        {
            _app = app;         
        }

        [HttpGet]
        [Route("Consolidated")]
        public async Task<ActionResult<FinancialConsolidatedResponse>> GetFinancialConsolidated([FromQuery] DateTime date)
        {
            try
            {                
                return await _app.GetFinancialConsolidated(date.Date);
            }catch(Exception ex) {
                return BadRequest("Erro ao acessar serviço. Detalhes: " + ex.Message);
            };
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostFinancial([FromQuery] FinancialDto financialPost)
        {
            try
            {
                return await _app.FinancialPost(financialPost.value, financialPost.financialType);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            };
        }
    }
}