using DAL;
using ModelFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BLL
{
    public class AlunoBLL
    {
        private readonly string _stringConexao;
        private readonly AlunoDAL _oDAL;

        public AlunoBLL(string stringConexao)
        {
            this._stringConexao = stringConexao;
            _oDAL = new AlunoDAL(stringConexao);
        }
        public List<Aluno> SelecionarTodos()
        {
            return _oDAL.SelecionarTodos();
        }
        public List<Aluno> SelecionarPorProfessor(int IdProfessor)
        {
            return _oDAL.SelecionarPorProfessor(IdProfessor);
        }

        public RetornaValidacao Cadastrar(Aluno aluno)
        {
            var retorno = new RetornaValidacao();
            if (aluno.Anexo != null)
            {
                var alunos = new DataTable();
                alunos.Columns.Add("Nome", typeof(String));
                alunos.Columns.Add("Valor", typeof(Decimal));
                alunos.Columns.Add("DataVencimento", typeof(DateTime));
                alunos.Columns.Add("IdProfessor", typeof(Int32));
                var stream = aluno.Anexo.OpenReadStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    var lines = reader.ReadToEnd().Split("\r\n");
                    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var n = i + 1;
                        var line = lines[i];
                        if (line != "")
                        {
                            var data = line.Split("||");
                            string NomeAluno;
                            decimal Valor;
                            DateTime DataVencimento;

                            if (data.Length > 3)
                            {
                                retorno.Sucesso = false;
                                retorno.Mensagem = $"A linha {n} possui mais muitos itens";
                                return retorno;
                            }
                            if (data.Length < 3)
                            {
                                retorno.Sucesso = false;
                                retorno.Mensagem = $"A linha {n} está faltando item(s)";
                                return retorno;
                            }
                            NomeAluno = data[0];
                            if (NomeAluno == "")
                            {
                                retorno.Sucesso = false;
                                retorno.Mensagem = $"A linha {n} não foi informado o nome do aluno";
                                return retorno;
                            }
                            if(NomeAluno.Length > 200)
                            {
                                retorno.Sucesso = false;
                                retorno.Mensagem = $"A linha {n} possui um nome de aluno muito grande";
                                return retorno;
                            }
                            try
                            {
                                Valor = decimal.Parse(data[1]);

                            }
                            catch (Exception ex)
                            {
                                retorno = new RetornaValidacao(ex);
                                retorno.Mensagem = $"Linha {n}: {retorno.Mensagem}";
                                return retorno;
                            }
                            try
                            {
                                DataVencimento = DateTime.Parse(data[2]).Date;
                            }
                            catch (Exception ex)
                            {
                                retorno = new RetornaValidacao(ex);
                                retorno.Mensagem = $"Linha {n}: {retorno.Mensagem}";
                                return retorno;
                            }

                            alunos.Rows.Add(NomeAluno, Valor, DataVencimento, aluno.Professor.Id);
                        }
                    }

                }
                return _oDAL.CadastrarEmLote(alunos);

            }
            if (aluno.Nome != null)
            {
                retorno = _oDAL.Cadastrar(aluno);
            }
            return retorno;
        }

        public RetornaValidacao ExcluirAluno(int idAluno)
        {
            return _oDAL.ExcluirAluno(idAluno);
        }
    }
}
