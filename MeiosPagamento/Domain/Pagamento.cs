using MeiosPagamento.Domain;
using System;

public class Pagamento
{
        public int Codigo { get; set; }
        public string? NomeCliente { get; set; }
        public double Valor { get; set; }
		public string? TipoPagamento { get; set;}
        public string? InformacaoPagamento { get; set; }

}
