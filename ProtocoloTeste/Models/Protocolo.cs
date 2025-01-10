using System.ComponentModel.DataAnnotations;

namespace ProtocoloTeste.Models
{
    public class Protocolo
    {
        [Key]
        public int IdProtocolo { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataAbertura { get; set; }
        [Required]
        public DateTime DataFechamento { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int ProtocoloStatusId { get; set; }
        public StatusProtocolo ProtocoloStatus { get; set; }

        public ICollection<ProtocoloFollow> ProtocoloFollows { get; set; }
    }
}
    