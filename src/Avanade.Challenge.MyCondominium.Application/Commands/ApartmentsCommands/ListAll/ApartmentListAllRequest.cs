using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentListAllRequest : IRequest<ApartmentListAllViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}