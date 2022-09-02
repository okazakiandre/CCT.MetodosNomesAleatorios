using CCT.MetodosNomesAleatorios.App;

namespace CCT.MetodosNomesAleatorios.UnitTest
{
    //[TestClass]
    public class PedidoRefatTest
    {
        [TestMethod]
        public void DeveriaIndicarQueEhValidoParaEnvio()
        {
            var ped = new PedidoRefat { Status = 4 };
            var res = ped.EhValidoParaEnvio();
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhValidoParaEnvio()
        {
            var ped = new PedidoRefat { Status = 3 };
            var res = ped.EhValidoParaEnvio();
            Assert.IsFalse(res);

            ped.Status = 0;
            res = ped.EhValidoParaEnvio();
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalComImpostosDe27PorCento()
        {
            var ped = new PedidoRefat
            {
                ValorTotal = 100
            };
            var res = ped.CalcularValorTotalComImpostos();
            Assert.AreEqual(127m, res);
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhValidoParaInclusaoSemCodigo()
        {
            var ped = new PedidoRefat();
            var exc = Assert.ThrowsException<Exception>(() => 
                        ped.EhValidoParaInclusao()
                      );
            Assert.AreEqual("Código não foi informado", exc.Message);
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhValidoParaInclusaoSemDescricao()
        {
            var ped = new PedidoRefat
            { 
                Codigo = 1
            };
            var exc = Assert.ThrowsException<Exception>(() =>
                        ped.EhValidoParaInclusao()
                      );
            Assert.AreEqual("Descrição não foi informada", exc.Message);
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhValidoParaInclusaoComStatus2()
        {
            var ped = new PedidoRefat
            {
                Codigo = 1,
                Descricao = "aaa",
                Status = 2
            };

            var exc = Assert.ThrowsException<Exception>(() =>
                        ped.EhValidoParaInclusao()
                      );

            Assert.AreEqual("Status inválido", exc.Message);
        }

        [TestMethod]
        public void DeveriaIndicarQueEhValidoParaInclusao()
        {
            var ped = new PedidoRefat
            {
                Codigo = 1,
                Descricao = "aaa",
                Status = 1
            };
            var res = ped.EhValidoParaInclusao();
            Assert.IsTrue(res);
        }
    }
}