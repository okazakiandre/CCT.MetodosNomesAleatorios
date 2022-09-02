namespace CCT.MetodosNomesAleatorios.App
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public short Status { get; set; }
        public decimal ValorTotal { get; set; }

        public bool VerificaStatus() => Status > 3;

        public decimal ValorTotalComImpostos() => ValorTotal * 1.27m;

        public void Validar()
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
                ValorTotal = 0;
                throw new Exception("Status inválido");
            }
        }
    }
}
