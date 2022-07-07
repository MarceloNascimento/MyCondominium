
namespace Avanade.Challenge.MyCondominium.Domain.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {
        }

        public string Name { get; set; }
        public bool IsResident { get; set; }
        public decimal? CondominiumFee { get; set; }
        public Apartment Apartment { get; set; }
        public int? Block { get; set; }
    }
}
