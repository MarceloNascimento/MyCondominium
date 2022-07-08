namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public record ApartmentListAllViewModel
    {
        public IEnumerable<ApartmentListAllDto>? ApartmentDTOs { get; set; }        
    }
}