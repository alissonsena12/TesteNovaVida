using System;
using System.Collections.Generic;
using System.Text;

namespace ModelFactory
{
    public class RetornaValidacao
    {
        public RetornaValidacao()
        {

        }
        public RetornaValidacao(Exception ex)
        {
            this.Sucesso = false;
            this.Exception = ex;
            this.Mensagem = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public string ValorRetorno { get; set; }
        public Exception Exception { get; set; }
    }
}
