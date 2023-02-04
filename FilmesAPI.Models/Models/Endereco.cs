using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Domain.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório que o endereço tenha um logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "É obrigatório que o endereço tenha um número")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
