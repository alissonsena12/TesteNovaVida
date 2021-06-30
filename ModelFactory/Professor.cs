using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelFactory
{
    public class Professor
    {
        public Professor()
        {
            this.Alunos = new List<Aluno>();
        }

        [DisplayName("Id do Professor")]
        public int Id { get; set; }
        [DisplayName("Nome do Professor")]
        [Required]   
        [MaxLength(200)]
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
