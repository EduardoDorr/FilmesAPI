using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Domain.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataHoraInicio { get; set; }
    }
}
