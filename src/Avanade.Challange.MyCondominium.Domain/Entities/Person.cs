
namespace Avanade.Desafio.Condominio.Domain.Entities
{
    public class Person : BaseEntity
    {
        protected Person(DateTime dataAtualizacao) : base(dataAtualizacao)
        {
        }

        public string Name { get; set; }
        public bool isResident { get; set; }
        public decimal? CondominiumFee { get; set; }
        public Apartment Apartment { get; set; }
        public int? Block { get; set; }

    }
}
