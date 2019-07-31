using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces;
using Senai.CodeTur.Infra.Data.Repositorios;
using Senai.CodeTur.Servico.ViewModels;

namespace Senai.CodeTur.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        private IPacoteRepositorio _pacoteRepositorio;

        public PacoteController()
        {
            _pacoteRepositorio = new PacoteRepositorio();
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="pacote">Pacote a ser cadastrado</param>
        /// <returns>Retorna o pacote Cadastrado</returns>
        [HttpPost]
        public IActionResult Post(PacoteViewModel pacote)
        {
            try
            {
                PacoteDominio pacoteNovo = new PacoteDominio()
                {
                    Titulo = pacote.Titulo,
                    Descricao = pacote.Descricao,
                    UrlImagem = pacote.UrlImagem,
                    DataInicio = pacote.DataInicio,
                    DataFim = pacote.DataFim,
                    Ativo = pacote.Ativo
                };

                var pacoteRetorno = _pacoteRepositorio.Cadastrar(pacoteNovo);

                return Ok(pacoteRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("/listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pacoteRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("/listarativos")]
        public IActionResult ListarAtivos()
        {
            try
            {
                return Ok(_pacoteRepositorio.Listar().Where(x => x.Ativo));
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var pacote = _pacoteRepositorio.BuscarPorId(id);

                if (pacote == null)
                    return NotFound(new { mensagem = "Pacote não encontrado" });

                return Ok(pacote);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpPut("alterarstatus/{id}")]
        public IActionResult AlterarStatus(int id)
        {
            try
            {
                var pacote = _pacoteRepositorio.BuscarPorId(id);

                if (pacote == null)
                    return NotFound(new { mensagem = "Pacote não encontrado" });

                var pacoteRetorno = _pacoteRepositorio.AlterarStatus(id);

                return Ok(pacoteRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(PacoteViewModel pacote, int id)
        {
            try
            {
                var pacoteExiste = _pacoteRepositorio.BuscarPorId(id);

                if (pacoteExiste == null)
                    return NotFound(new { mensagem = "Pacote não encontrado" });

                PacoteDominio pacoteAlterar = new PacoteDominio()
                {
                    Id = pacote.Id,
                    Titulo = pacote.Titulo,
                    Descricao = pacote.Descricao,
                    UrlImagem = pacote.UrlImagem,
                    DataInicio = pacote.DataInicio,
                    DataFim = pacote.DataFim,
                    Ativo = pacote.Ativo
                };

                _pacoteRepositorio.Editar(pacoteAlterar);

                return Ok(pacoteAlterar);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}