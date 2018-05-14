using AsPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
