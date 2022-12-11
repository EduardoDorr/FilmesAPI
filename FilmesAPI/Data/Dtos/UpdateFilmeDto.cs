using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [StringLength(200, MinimumLength = 1, ErrorMessage = "O tamanho do título deve conter entre 1 e 200 caracteres")]
        public string Titulo { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O tamanho do gênero deve conter entre 1 e 50 caracteres")]
        public string Genero { get; set; }
        [Range(70, 600, ErrorMessage = "A duração do filme deve ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
