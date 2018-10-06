using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository
{
    public partial class CadastroUsuarioContext : DbContext
    {
        private static CadastroUsuarioContext ActiveContext { set; get; }
        private CadastroUsuarioContext()
        {
            ActiveContext = this;
        }

        private CadastroUsuarioContext(DbContextOptions<CadastroUsuarioContext> options)
            : base(options)
        {
            ActiveContext = this;
        }

        

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QVNNHQP\\SQLEXPRESS;Database=CadastroUsuario;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("Idx_CLIENTE_ID_VENDEDOR");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("fk_cliente_vendedor");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor);

                entity.ToTable("VENDEDOR");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }

        public static CadastroUsuarioContext GetSingleton() {
            if (ActiveContext == null)
            {
                ActiveContext = new CadastroUsuarioContext();
            }
            return ActiveContext;

        }
    }
}
