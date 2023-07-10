using System;
using System.Collections.Generic;
using System.Text;

namespace MeiosPagamento.Interfaces
{
    public interface IPagamentoService
    {
        List<Pagamento> Get();
        void SalvarPagamento(Pagamento userViewModel);
        void EditarPagamento(Pagamento userViewModel);
        void DeletarPagamento(int codigo);
    }
}
