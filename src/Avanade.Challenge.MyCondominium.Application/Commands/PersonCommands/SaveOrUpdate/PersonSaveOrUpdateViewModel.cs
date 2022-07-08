namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class PersonSaveOrUpdateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsResident { get; set; }
        public decimal? CondominiumFee { get; set; }               
    }
}