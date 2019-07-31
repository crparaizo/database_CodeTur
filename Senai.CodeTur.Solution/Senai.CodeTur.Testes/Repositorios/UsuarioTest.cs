using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces;
using Senai.CodeTur.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Senai.CodeTur.Teste.XUnit.Repositorios
{
    public class UsuarioTest
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioTest()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [Fact]
        public void UsuarioInvalido () //Teste válido porque o valor retornado é nulo (não está no banco)
        {
            var retornaUsuario = _usuarioRepositorio.EfetuarLogin("teste@teste.com", "12345");

            Assert.Null(retornaUsuario); //Retorna nulo
        }

        [Fact]
        public void SenhaNaoInformada ()
        {
            var retornaUsuario = _usuarioRepositorio.EfetuarLogin("admin@admin.com", "");

            Assert.Null(retornaUsuario);
        }

        [Fact]
        public void UsuarioValido()
        {
            var usuarioEsperado = new UsuarioDominio()
            {
                Email = "admin@admin.com",
                Senha = "12345"
            };

            var usuarioAtual = _usuarioRepositorio.EfetuarLogin(usuarioEsperado.Email, usuarioEsperado.Senha);

            Assert.Equal(usuarioEsperado.Email, usuarioAtual.Email);
            Assert.Equal(usuarioEsperado.Senha, usuarioAtual.Senha);
        }
    }
}