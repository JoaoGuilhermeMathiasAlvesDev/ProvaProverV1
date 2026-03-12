using Dominio.Entity;
using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnitario
{
    public class AssinanteTest
    {
        [Fact]
        public void CriandoAssinante_DadosValidos()
        {
            var nome = "João Guilherme";
            var email = "joao@email.com";
            var valor = 100.0;
            var dataInicio = DateTime.Now.AddMonths(-2);

            var NovoAnssinate = new Assinante (nome, email,PlanoEnum.Padrao ,valor,dataInicio);

            Assert.NotNull (NovoAnssinate);
            Assert.Equal(email, NovoAnssinate.Email);
            Assert.Equal(valor, NovoAnssinate.Valor);
            Assert.Equal(dataInicio, NovoAnssinate.DataInicio);
            Assert.True(NovoAnssinate.Status);
            Assert.Equal(2, NovoAnssinate.TempoAssinaturaEmMeses);

        }

        [Fact]
        public void AoAdiconarIraDarErroDataFutura()
        {
            var dataFutura = DateTime.Now.AddMonths(1);

            var ex = Assert.Throws<ArgumentException>(() => new Assinante("Nome", "e@e.com",
                PlanoEnum.Padrao, 50, dataFutura));
                Assert.Equal("A data de início não pode ser maior que a data atual.", ex.Message);
        }


        [Fact]
        public void AoAdicionarComValorIncorretoDeveRetornaErro()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Assinante("Nome", "e@e.com",
               PlanoEnum.Padrao, 0, DateTime.Now));

            Assert.Equal("O valor mensal da assinatura deve ser maior que 0.", ex.Message);
        }

        [Fact]
        public void quandoAssinaturaERecenteDeveRetornaUmMes()
        {
            var novaAssinatura = new Assinante("Nome", "e@e.com",
               PlanoEnum.Padrao, 150, DateTime.Now);

            var mes = novaAssinatura.TempoAssinaturaEmMeses;

            Assert.Equal(1, mes);
        }
    }
    
}
