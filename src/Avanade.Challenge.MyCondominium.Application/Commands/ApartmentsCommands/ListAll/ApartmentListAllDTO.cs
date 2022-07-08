namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentListAllDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Block { get; set; }
        public DateTime Created { get; set; }
    }
}