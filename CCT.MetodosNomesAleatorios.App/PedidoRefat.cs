namespace CCT.MetodosNomesAleatorios.App
{
    public class PedidoRefat
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public short Status { get; set; }
        public decimal ValorTotal { get; set; }

        public bool EhValidoParaEnvio() => Status > 3;

        public decimal CalcularValorTotalComImpostos() => ValorTotal * 1.27m;

        public bool EhValidoParaInclusao()
        {
            if (Codigo <= 0) 
            { 
                throw new Exception("Código não foi informado");
            }
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição não foi informada");
            }
            if (Status == 2)
            {
                throw new Exception("Status inválido");
            }
            return true;
        }
    }
}
