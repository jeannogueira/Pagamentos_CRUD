using System;
using System.Collections.Generic;
using System.Text;

namespace MeiosPagamento.Interfaces
{
    public interface IPagamentoRepository
    {
        List<Pagamento> GetAll();
        void Create(Pagamento pagamento);
        void Update(Pagamento pagamento);
        void Delete(int codigo);
    }
}
