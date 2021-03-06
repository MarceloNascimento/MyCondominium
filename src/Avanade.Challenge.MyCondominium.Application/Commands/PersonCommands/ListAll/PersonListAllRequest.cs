using MediatR;

namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class PersonListAllRequest : IRequest<PersonListAllViewModel>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }
    }
}