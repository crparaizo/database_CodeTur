using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces;
using Senai.CodeTur.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Senai.CodeTur.Infra.Data.Repositorios
{
    /// <summary>
    /// Classe responsável pelo acesso aos dados da tabela pacotes
    /// </summary>
    public class PacoteRepositorio : IPacoteRepositorio
    {
        /// <summary>
        /// Altera o status do pacote
        /// </summary>
        /// <param name="id">Id do pacote a ser alterado</param>
        /// <returns>Retorna o pacote alterado</returns>
        public PacoteDominio AlterarStatus(int id)
        {
            try
            {
                var pacote = BuscarPorId(id);

                if (pacote != null)
                {
                    pacote.Ativo = !pacote.Ativo;
                    Editar(pacote);
                    return pacote;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um pacote pelo seu Id
        /// </summary>
        /// <param name="id">Id do pacote</param>
        /// <returns>Retorna um pacote</returns>
        public PacoteDominio BuscarPorId(int id)
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    return ctx.Pacotes.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="pacote">Pacote a ser cadastrado</param>
        public PacoteDominio Cadastrar(PacoteDominio pacote)
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    ctx.Pacotes.Add(pacote);
                    ctx.SaveChanges();
                    return pacote;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Edita um pacote
        /// </summary>
        /// <param name="pacote">pacote a ser Editado</param>
        /// <returns>Retorna o pacote editado</returns>
        public PacoteDominio Editar(PacoteDominio pacote)
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    ctx.Entry<PacoteDominio>(pacote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    ctx.SaveChanges();
                    return pacote;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExcluirPacote(int id)
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    var pacote = BuscarPorId(id);

                    ctx.Entry<PacoteDominio>(pacote).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Retorna uma lista de pacotes</returns>
        public List<PacoteDominio> Listar()
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    return ctx.Pacotes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}