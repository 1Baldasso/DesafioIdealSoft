using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioIdealSoft.DataAccess;

public interface IPessoaRepository
{
    IEnumerable<Pessoa> ObterTodos();
    Pessoa ObterPorId(Guid id);
    void Adicionar(Pessoa pessoa);
    void Editar(Pessoa pessoa);
    void Remover(Pessoa pessoa);
}