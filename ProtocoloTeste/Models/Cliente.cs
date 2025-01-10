using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProtocoloTeste.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(300)]
        public string Endereco { get; set; }

        public ICollection<Protocolo> Protocolos { get; set; }
    }
}
