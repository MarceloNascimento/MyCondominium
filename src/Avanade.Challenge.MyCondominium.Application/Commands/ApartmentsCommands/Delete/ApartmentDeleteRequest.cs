using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentDeleteRequest : IRequest<ApartmentViewModel>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}