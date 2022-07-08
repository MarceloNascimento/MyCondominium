using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentSaveOrUpdateRequest : IRequest<ApartmentSaveOrUpdateViewModel>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
    }
}