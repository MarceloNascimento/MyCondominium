using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class PersonSaveOrUpdateRequest : IRequest<PersonSaveOrUpdateViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsResident { get; set; }
        public decimal? CondominiumFee { get; set; }
        public int ApartmentId { get; set; }
        public int Block { get; set; }
    }
}