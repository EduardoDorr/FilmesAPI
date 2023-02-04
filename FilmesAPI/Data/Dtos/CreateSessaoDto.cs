using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateSessaoDto
    {
        [Required]
        public DateTime DataHoraInicio { get; set; }
    }
}
