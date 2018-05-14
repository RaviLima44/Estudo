using AsPromocoes.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AsPromocoes.Infrastructure.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.produtoId);

            Property(p => p.Nome).IsRequired().HasMaxLength(250);

            Property(p => p.Valor).IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

        }
    }
}
