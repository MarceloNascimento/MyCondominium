using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Challenge.MyCondominium.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        public Apartment() : base()
        {
        }

        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}
