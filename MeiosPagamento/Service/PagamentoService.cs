using MeiosPagamento.Interfaces;
using MeiosPagamento.Producer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MeiosPagamento.Services
{
    public class PagamentoService : IPagamentoService
    {

        private readonly IPagamentoRepository pagamentoRepository;
        private readonly PublishSave publishSave;

        public PagamentoService(IPagamentoRepository pagamentoRepository, PublishSave publishSave)
        {
            this.pagamentoRepository = pagamentoRepository;
            this.publishSave = publishSave;
        }

        public List<Pagamento> Get()
        {
            var pagamentos = this.pagamentoRepository.GetAll();

            return pagamentos;
        }

        public void SalvarPagamento(Pagamento pagamento)
        {
            publishSave.Save(pagamento);
        }

        public void EditarPagamento(Pagamento pagamento)
        {
         
            this.pagamentoRepository.Update(pagamento);

        }

        public void DeletarPagamento(int codigo)
        {
            if (codigo.Equals(null))
            {
                throw new Exception("O pagamento não é válido");
            }

            this.pagamentoRepository.Delete(codigo);
        }

    }
}
