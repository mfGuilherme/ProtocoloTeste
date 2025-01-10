using System.ComponentModel.DataAnnotations;

namespace ProtocoloTeste.Models
{
    public class ProtocoloFollow
    {
        [Key]
        public int IdFollow { get; set; }

        [Required]
        public int ProtocoloId { get; set; }
        public Protocolo Protocolo { get; set; }

        [Required]
        public DateTime DataAcao { get; set; }

        [Required]
        [StringLength(500)]
        public string DescricaoAcao { get; set; }
    }
}
