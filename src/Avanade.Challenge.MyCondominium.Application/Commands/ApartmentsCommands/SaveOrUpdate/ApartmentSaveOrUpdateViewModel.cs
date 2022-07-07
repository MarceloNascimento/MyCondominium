namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentSaveOrUpdateViewModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Floor { get; set; }
        public int Block { get; set; }


        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}