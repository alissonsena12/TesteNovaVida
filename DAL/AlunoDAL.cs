using ModelFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class AlunoDAL : MasterDAL
    {        

        public AlunoDAL(string stringConexao)
        {
            cn = new SqlConnection(stringConexao);
        }

        public List<Aluno> SelecionarTodos()
        {
            var ds = ExecutaDataSet("select * from Alunos as A join Professores as p on a.IdProfessor = p.Id", CommandType.Text, null);
            var retorno = new List<Aluno>();
            if (ds.Tables.Count > 0)
            {
                Parallel.ForEach(ds.Tables[0].AsEnumerable(), row => {
                    retorno.Add(DataRowParaModel(row, true));
                });
                retorno = retorno.OrderBy(x => x.Id).ToList();
            }
            return retorno;
        }

        private Aluno DataRowParaModel(DataRow row, bool carregaProfessor = false)
        {
            var aluno =  new Aluno
            {
                Id = int.Parse(row["Id"].ToString()),
                Nome = row["Nome"].ToString(),
                ValorMensalidade = decimal.Parse(row["Valor"].ToString()),
                DataVencimento = DateTime.Parse(row["DataVencimento"].ToString())
            };
            if (carregaProfessor)
            {
                aluno.Professor = new Professor
                {
                    Id = int.Parse(row[5].ToString()),
                    Nome = row[6].ToString(),
                };
            }
            return aluno;
        }

        public List<Aluno> SelecionarPorProfessor(int idProfessor)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@IdProfessor", DbType = DbType.Int32, Value = idProfessor } };
            var ds = ExecutaDataSet("select * from Alunos as A join Professores as p on a.IdProfessor = p.Id where p.Id = @IdProfessor", CommandType.Text, param);
            var retorno = new List<Aluno>();
            if (ds.Tables.Count > 0)
            {
                Parallel.ForEach(ds.Tables[0].AsEnumerable(), row => {
                    retorno.Add(DataRowParaModel(row, true));
                });
                retorno = retorno.OrderBy(x => x.Id).ToList();
            }
            return retorno;
        }

        public RetornaValidacao Cadastrar(Aluno aluno)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@Nome", DbType = DbType.String, Value = aluno.Nome }
                                                        ,new SqlParameter { ParameterName = "@Valor", DbType = DbType.Decimal, Value = aluno.ValorMensalidade}             
                                                        ,new SqlParameter { ParameterName = "@DataVencimento", DbType = DbType.DateTime, Value = aluno.DataVencimento}            
                                                        ,new SqlParameter { ParameterName = "@IdProfessor", DbType = DbType.Int32, Value = aluno.Professor.Id}            
            };
            try
            {
                var dr = ExecutaDataSet("prAlunos_Insert", CommandType.StoredProcedure, param);                
                var retorno = new RetornaValidacao();
                retorno.Sucesso = true;
                retorno.Mensagem = "Item cadastrado com sucesso";
                return retorno;
            }
            catch (Exception ex)
            {
                return new RetornaValidacao(ex);

            }
        }

        public RetornaValidacao CadastrarEmLote(DataTable alunos)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@ListaAlunos", SqlDbType = SqlDbType.Structured, Value = alunos }
                                                        ,new SqlParameter { ParameterName = "@Tipo", DbType = DbType.String, Value = "LOTE"}            
                                                                 
            };
            try
            {
                var dr = ExecutaDataSet("prAlunos_Insert", CommandType.StoredProcedure, param);                
                var retorno = new RetornaValidacao();
                retorno.Sucesso = true;
                retorno.Mensagem = "Itens cadastrados com sucesso";
                return retorno;
            }
            catch (Exception ex)
            {
                return new RetornaValidacao(ex);

            }
        }

        public RetornaValidacao ExcluirAluno(int idAluno)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] { new SqlParameter { ParameterName = "@idAluno", SqlDbType = SqlDbType.Int, Value = idAluno }};
                var dr = ExecutaDataSet("delete Alunos where Id = @idAluno", CommandType.Text, param);
                var retorno = new RetornaValidacao();
                retorno.Sucesso = true;
                retorno.Mensagem = "Cadastro deletado com sucesso";
                return retorno;
            }
            catch (Exception ex)
            {
                return new RetornaValidacao(ex);

            }
        }
    }
}
