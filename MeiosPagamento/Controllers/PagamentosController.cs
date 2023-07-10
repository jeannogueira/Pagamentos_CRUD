using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MeiosPagamento.Domain;
using MeiosPagamento.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeiosPagamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentosController : ControllerBase
    {

        private readonly IPagamentoService pagamentoService;

        public PagamentosController(IPagamentoService pagamentoService)
        {
            this.pagamentoService = pagamentoService;
        }

        [HttpGet]
        public List<Pagamento> Get()
        {    
            var pagamentos = pagamentoService.Get();

            return pagamentos;

        }

        [HttpPost]
        public IActionResult Post(Pagamento pagamento)
        {
            if(String.IsNullOrWhiteSpace(pagamento.NomeCliente) 
                || String.IsNullOrWhiteSpace(pagamento.TipoPagamento)
                || String.IsNullOrWhiteSpace(pagamento.InformacaoPagamento)
                || pagamento.Valor.Equals(0))
            {
                return Ok(false);
            }

            pagamentoService.SalvarPagamento(pagamento);

            return Ok(true);
        }

        [HttpPut]
        public IActionResult Put(Pagamento pagamento)
        {
            pagamentoService.EditarPagamento(pagamento);
            
            return Ok(true);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            pagamentoService.DeletarPagamento(codigo);

            return Ok(true);
        }

    }
}
