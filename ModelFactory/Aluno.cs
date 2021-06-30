using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModelFactory
{
    public class Aluno
    {
        public Aluno()
        {
            this.Professor = new Professor();
            DataVencimento = DateTime.Now.Date;
        }

        [DisplayName("Id do Aluno")]
        public int Id { get; set; }
        [DisplayName("Nome do Aluno")]
        public string Nome { get; set; }
        [DisplayName("Valor Mensalidade")]
        public decimal ValorMensalidade { get; set; }
        [DisplayName("Data Vencimento")]
        public DateTime DataVencimento { get; set; }
        public Professor Professor { get; set; }
        public IFormFile Anexo { get; set; }
    }
}
