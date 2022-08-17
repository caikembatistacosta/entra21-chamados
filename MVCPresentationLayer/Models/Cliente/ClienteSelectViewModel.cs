using System.ComponentModel.DataAnnotations;

namespace MVCPresentationLayer.Models.Cliente
{
    public class ClienteSelectViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
