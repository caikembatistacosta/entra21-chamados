using System.ComponentModel.DataAnnotations;

namespace MVCPresentationLayer.Models.Cliente
{
    public class ClienteInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 30 caracteres.")]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        [Required(ErrorMessage ="O email deve ser informado.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
