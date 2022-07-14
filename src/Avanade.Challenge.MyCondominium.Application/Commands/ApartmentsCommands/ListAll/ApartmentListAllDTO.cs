namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public record ApartmentListAllDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
        public DateTime? Created { get; set; }
    }
}