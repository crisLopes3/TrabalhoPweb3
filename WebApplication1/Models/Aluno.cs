﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Ramo? Ramo { get; set; }

        [Required]
        public string DisciplinasPorFazer { get; set; }

        [Required]
        public string DisciplinasFeitas { get; set; }

        //  [ForeignKey("PropostaAtribuida")]
        public int? PropostaId { get; set; }
        //     public Proposta PropostaAtribuida { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IList<Proposta> Preferencias { get; set; }

        public Aluno()
        {
            Preferencias = new List<Proposta>();
        }
    }
}