using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Domain.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo endereço id é necessário")]
        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
