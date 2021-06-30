using DAL;
using ModelFactory;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ProfessorBLL
    {
        private readonly string _stringConexao;
        private readonly ProfessorDAL _oDAL;

        public ProfessorBLL(string stringConexao)
        {
            this._stringConexao = stringConexao;
            _oDAL = new ProfessorDAL(stringConexao);
        }
        public List<Professor> SelecionarTodos()
        {
            return _oDAL.SelecionarTodos(); ;
        }
        public Professor SelecionarProfessor(int idProfessor)
        {
            return _oDAL.SelecionarProfessor(idProfessor);
        }
        public RetornaValidacao Cadastrar(Professor professor)
        {
            try
            {
                return _oDAL.Cadastrar(professor);
            }
            catch (Exception ex)
            {
                var retorno = new RetornaValidacao(ex);                
                return retorno;
            }
        }
    }
}
