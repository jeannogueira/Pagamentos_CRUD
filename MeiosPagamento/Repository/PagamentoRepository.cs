using MeiosPagamento.Interfaces;
using MeiosPagamento.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MeiosPagamento.Services
{
    public class PagamentoRepository : IPagamentoRepository
    {
   
        public List<Pagamento> GetAll()
        {
            return Banco.GetAll();
        }

        public void Create(Pagamento pagamento)
        {
            Banco.Add(pagamento);
        }
        public void Update(Pagamento pagamento)
        {
            Banco.Edit(pagamento);
        }
        public void Delete(int codigo)
        {
            Banco.Remove(codigo);
        }
    }
}
