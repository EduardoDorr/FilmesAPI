using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo endereço id é necessário")]
        public int Enderecoid { get; set; }
    }
}
