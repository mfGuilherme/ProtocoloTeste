using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ProtocoloTeste.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ProtocoloDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Protocolo> Protocolos { get; set; }
        public DbSet<ProtocoloFollow> ProtocoloFollows { get; set; }
        public DbSet<StatusProtocolo> StatusProtocolos { get; set; }
        public ProtocoloDbContext(DbContextOptions<ProtocoloDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Protocolo>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Protocolos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Protocolo>()
                .HasOne(p => p.ProtocoloStatus)
                .WithMany()
                .HasForeignKey(p => p.ProtocoloStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProtocoloFollow>()
                .HasOne(pf => pf.Protocolo)
                .WithMany(p => p.ProtocoloFollows)
                .HasForeignKey(pf => pf.ProtocoloId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
