using AsPromocoes.Domain.Entities;
using AsPromocoes.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsPromocoes.Infrastructure.Data.Contexto
{
    public class AsPromocoesContext : DbContext
    {
        public AsPromocoesContext()
            : base("AsPromocoes")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Não fica plurarizando as tabelas quando criadas via EF.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Não deleta em cascada quando tem uma relação de 1 pra N
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Não deleta em cascada quando tem uma relação N pra N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando uma propriedade tiver ID no final do nome ela será uma Primary Key
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            // Tudo que for criado como string será varchar em vez de Nvarhcar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Quando nao for informado tamanho da string será tamanho defaut de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Usa as configurações das propriedade feitas em EntityConfig (Fluent API)
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro")!=null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}
