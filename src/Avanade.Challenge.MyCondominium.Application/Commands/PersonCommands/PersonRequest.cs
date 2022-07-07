using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class PersonRequest : IRequest<PersonViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsResident { get; set; }
        public decimal? CondominiumFee { get; set; }
        public int ApartmentId { get; set; }
        public int? Block { get; set; }

    }
}