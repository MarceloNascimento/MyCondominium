﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Desafio.Condominio.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        protected Apartment(DateTime dataAtualizacao) : base(dataAtualizacao)
        {
        }

        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}