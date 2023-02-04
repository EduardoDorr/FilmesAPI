using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Domain.Models
{
    public class Sessao
    {
        public int? FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        [Required]
        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFinal { get; set; }
    }
}
