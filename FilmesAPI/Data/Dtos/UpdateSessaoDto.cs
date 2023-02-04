using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateSessaoDto
    {
        [Required]
        public DateTime DataHoraInicio { get; set; }
    }
}
