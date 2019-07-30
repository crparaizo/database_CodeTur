using Senai.CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.CodeTur.Dominio.Interfaces
{
    /// <summary>
    /// Contratos da classe Usuário
    /// </summary>
    public interface IUsuarioRepositorio
    {
        UsuarioDominio EfetuarLogin(string email, string senha);
    }
}
