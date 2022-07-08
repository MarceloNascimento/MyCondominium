namespace Avanade.Challenge.MyCondominium.Domain.Entities
{
    public class Apartment : EntityBase
    {
        public Apartment() : base()
        {
        }

        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
    }
}
