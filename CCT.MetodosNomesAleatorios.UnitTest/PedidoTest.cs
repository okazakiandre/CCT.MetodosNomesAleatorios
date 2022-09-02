using CCT.MetodosNomesAleatorios.App;

namespace CCT.MetodosNomesAleatorios.UnitTest
{
    [TestClass]
    public class PedidoTest
    {
        [TestMethod]
        public void DeveriaVerificarStatus()
        {
            var ped = new Pedido();
            var res = ped.VerificaStatus();
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void ValorTotalComImpostos_Valido()
        {
            var ped = new Pedido
            {
                ValorTotal = 100
            };
            var res = ped.ValorTotalComImpostos();
            Assert.AreEqual(127m, res);
        }

        [TestMethod]
        public void ValorTotalComImpostos_Invalido()
        {
            var ped = new Pedido
            {
                ValorTotal = 100
            };
            var res = ped.ValorTotalComImpostos();
            Assert.AreNotEqual(120m, res);
        }

        [TestMethod]
        public void Validar_GerouException_Codigo()
        {
            var ped = new Pedido();
            var exc = Assert.ThrowsException<Exception>(() => ped.Validar());
            Assert.AreEqual("Código não foi informado", exc.Message);
        }

        [TestMethod]
        public void Validar_GerouException_Descricao()
        {
            var ped = new Pedido 
            { 
                Codigo = 1
            };
            var exc = Assert.ThrowsException<Exception>(() => ped.Validar());
            Assert.AreEqual("Descrição não foi informada", exc.Message);
        }

        [TestMethod]
        public void Validar_GerouException_Status()
        {
            var ped = new Pedido
            {
                Codigo = 1,
                Descricao = "aaa",
                Status = 2,
                ValorTotal = 10
            };

            var exc = Assert.ThrowsException<Exception>(() => ped.Validar());

            Assert.AreEqual("Status inválido", exc.Message);
            Assert.AreEqual(0, ped.ValorTotal);
        }

        [TestMethod]
        public void Validar_NaoGerouException()
        {
            var ped = new Pedido
            {
                Codigo = 1,
                Descricao = "aaa",
                Status = 3,
                ValorTotal = 10
            };
            ped.Validar();
            Assert.AreEqual(10, ped.ValorTotal);
        }
    }
}