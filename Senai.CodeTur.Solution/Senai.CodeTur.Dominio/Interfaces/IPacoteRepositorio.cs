using Senai.CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.CodeTur.Dominio.Interfaces
{
    public interface IPacoteRepositorio
    {
        PacoteDominio Cadastrar(PacoteDominio pacote);

        PacoteDominio Editar(PacoteDominio pacote);

        PacoteDominio AlterarStatus(int id);

        PacoteDominio BuscarPorId(int id);

        bool ExcluirPacote(int id);

        List<PacoteDominio> Listar();
    }
}