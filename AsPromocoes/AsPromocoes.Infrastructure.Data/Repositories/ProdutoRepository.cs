using System;
using System.Collections.Generic;
using AsPromocoes.Domain.Entities;
using AsPromocoes.Domain.Interfaces;
using System.Linq;

namespace AsPromocoes.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
