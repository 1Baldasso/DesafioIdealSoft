using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioIdealSoft.DataAccess;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> ObterTodosAsync();
    Task<Pessoa> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Pessoa pessoa);
    Task EditarAsync(Pessoa pessoa);
    Task RemoverAsync(Pessoa pessoa);
}