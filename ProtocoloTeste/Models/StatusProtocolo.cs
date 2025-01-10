using System.ComponentModel.DataAnnotations;

namespace ProtocoloTeste.Models
{
    public class StatusProtocolo
    {
        [Key]
        public int IdStatus { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeStatus { get; set; }
    }
}
