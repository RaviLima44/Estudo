using AsPromocoes.Domain.Entities;
using System.Data.Entity;

namespace AsPromocoes.Infrastructure.Data.Contexto
{
  public  class AsPromocoesContext : DbContext
    {
        public AsPromocoesContext() :base("ConexaoAsPromocoes")
        {

        }

        public DbSet<Cliente> MyProperty { get; set; }
    }
}
