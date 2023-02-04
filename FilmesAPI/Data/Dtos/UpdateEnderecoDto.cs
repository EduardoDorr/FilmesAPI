using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "É obrigatório que o endereço tenha um logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "É obrigatório que o endereço tenha um número")]
        public int Numero { get; set; }

        public string Complemento { get; set; }
    }
}
