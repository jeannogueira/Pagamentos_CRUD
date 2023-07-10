namespace MeiosPagamento.Repository
{
    public static class Banco
    {
        private static List<Pagamento>? db;

        public static void Add(Pagamento pagamento)
        {
            if(db == null)
            {
                db = new List<Pagamento>();
            }

            var codigoRandom = new Random();

            pagamento.Codigo = codigoRandom.Next(10, 1000);
            db.Add(pagamento);
        }

        public static void Remove(int codigo)
        {

           var index = db.FindIndex(x => x.Codigo == codigo);

            db.RemoveAt(index);
        }

        public static void Edit(Pagamento pagamento)
        {

            var index = db.FindIndex(x => x.Codigo == pagamento.Codigo);

            db[index].NomeCliente = pagamento.NomeCliente;
            db[index].Valor = pagamento.Valor;
            db[index].TipoPagamento = pagamento.TipoPagamento;
            db[index].InformacaoPagamento = pagamento.InformacaoPagamento;

        }

        public static List<Pagamento> GetAll()
        {
            if (db == null)
            {
                db = new List<Pagamento>();
            }

            return db;
        }



    }
}
