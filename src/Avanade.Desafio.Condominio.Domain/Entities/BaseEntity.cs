
namespace Avanade.Desafio.Condominio.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity(
         DateTime dataAtualizacao)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;//new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DataAtualizacao = dataAtualizacao;
        }

        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
