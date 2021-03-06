﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IList<Proposta> Propostas { get; set; }

        public Empresa()
        {
            Propostas = new List<Proposta>();
        }
    }
}