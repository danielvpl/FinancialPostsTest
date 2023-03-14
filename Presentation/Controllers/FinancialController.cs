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

        /// <summary>
        /// PostFinancial - Realizar lançamento financeiro
        /// </summary>
        /// <param name="financialPost">
        /// Informar um valor decimal no parâmetro 'value'. Ex: 10.5
        /// Informar o valor 0 ou 1 para o parâmetro financialType, onde 0 = Crédito e 1 = Débito
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> PostFinancial(FinancialDto financialPost)
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