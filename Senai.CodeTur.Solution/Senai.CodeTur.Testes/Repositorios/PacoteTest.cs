using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces;
using Senai.CodeTur.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Senai.CodeTur.Teste.XUnit.Repositorios
{
    public class PacoteTest
    {
        private IPacoteRepositorio _pacoteRepositorio;

        public PacoteTest()
        {
            _pacoteRepositorio = new PacoteRepositorio();
        }

        [Fact]
        public void CadastraDeletaPacote()
        {
            PacoteDominio pacote = new PacoteDominio()
            {
                Titulo = "Pacote para o Vale do Silício",
                Descricao = "Conheça o Polo Tecnológico do Vale do Silício, converse com diversos CEO das maiores empresas do mundo.",
                Ativo = true,
                UrlImagem = "https://apidiag276.blob.core.windows.net/api/portal/2016/10/foto-800.png", //Endereço da imagem - botão direito
                DataInicio = new System.DateTime(2019, 10, 9),
                DataFim = new System.DateTime(2019, 10, 15)
            };

            var pacoteRetorno = _pacoteRepositorio.Cadastrar(pacote);

            Assert.NotNull(pacoteRetorno);
            Assert.Equal(pacoteRetorno.Titulo, pacote.Titulo);

            bool sucesso = _pacoteRepositorio.ExcluirPacote(pacoteRetorno.Id);

            Assert.True(sucesso);
        }

        [Theory]
        [InlineData(1,1)] //Busca o Id 1 e verifica se retornou o Id 1
        [InlineData(2,2)] //Busca o Id 2 e verifica se retornou o Id 2

        public void BuscarPorId (int id, int esperado)
        {
            var retornoPacote = _pacoteRepositorio.BuscarPorId(id);

            Assert.Equal(retornoPacote.Id, esperado);
        }
    }
}
