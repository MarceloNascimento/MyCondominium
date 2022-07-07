namespace Avanade.Challenge.MyCondominium.API.ViewModels
{
    public class ApartmentDeletedViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public string Block { get; set; }
        public DateTime Created { get; set; }

        public ApartmentDeletedViewModel(int id, string name, string floor, string block)
        {
            this.Id = id;
            this.Name = name;
            this.Floor = floor;
            this.Block = block;
        }

        public ApartmentDeletedViewModel()
        {
        }
    }
}