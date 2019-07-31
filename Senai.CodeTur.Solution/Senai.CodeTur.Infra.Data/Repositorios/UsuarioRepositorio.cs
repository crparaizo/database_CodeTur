using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces;
using Senai.CodeTur.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Senai.CodeTur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public UsuarioDominio EfetuarLogin(string email, string senha)
        {
            try
            {
                using (CodeTurContext ctx = new CodeTurContext())
                {
                    return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}