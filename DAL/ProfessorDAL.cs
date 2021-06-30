using ModelFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class ProfessorDAL : MasterDAL
    {                
        public ProfessorDAL(string stringConexao)
        {            
            cn = new SqlConnection(stringConexao);
        }

        public List<Professor> SelecionarTodos()
        {
            var ds = ExecutaDataSet("select * from Professores", CommandType.Text, null);
            var retorno = new List<Professor>();
            if (ds.Tables.Count > 0)
            {
                Parallel.ForEach(ds.Tables[0].AsEnumerable(), row => {
                    retorno.Add(DataRowParaModel(row));
                });
                retorno = retorno.OrderBy(x => x.Id).ToList();
            }
            return retorno;
        }

        public Professor SelecionarProfessor(int idProfessor)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = idProfessor } };
            var ds = ExecutaDataSet("select * from Professores where Id = @Id", CommandType.Text, param);
            var retorno = new Professor();
            if (ds.Tables.Count > 0)
            {                
                retorno = DataRowParaModel(ds.Tables[0].Rows[0]);
            }                
            
            return retorno;
        }

        public RetornaValidacao Cadastrar(Professor professor)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@Nome", DbType = DbType.String, Value = professor.Nome } };
            try
            {
                var dr = ExecutaDataSet("prProfessores_Insert", CommandType.StoredProcedure, param);
                var cadastrado = bool.Parse(dr.Tables[0].Rows[0]["Cadastrado"].ToString());
                var retorno = new RetornaValidacao();
                retorno.Sucesso = cadastrado;
                retorno.Mensagem = cadastrado ? "Item cadastrado com sucesso" : "Já existe um professor com esse nome cadastrado";
                return retorno;
            }
            catch (Exception ex)
            {
                return new RetornaValidacao(ex);
                
            }

        }
        
        public Professor DataRowParaModel(DataRow row)
        {
            return new Professor
            {
                Id = int.Parse(row["Id"].ToString()),
                Nome = row["Nome"].ToString()
            };
        }
    }
}
