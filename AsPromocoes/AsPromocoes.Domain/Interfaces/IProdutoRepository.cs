using AsPromocoes.Domain.Entities;
using System.Collections.Generic;

namespace AsPromocoes.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
