
namespace Avanade.Challenge.MyCondominium.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            LastUpdated = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
