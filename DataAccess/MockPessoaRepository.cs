using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioIdealSoft.DataAccess;

public class PessoaRepository : IPessoaRepository
{
    private List<Pessoa> pessoas;
    public PessoaRepository()
    {
        pessoas = new Pessoa[]
        {
            new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "João", Sobrenome = "Silva", Telefone = "1199999999"
            },
            new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Ana", Sobrenome = "Souza", Telefone = "11999999999"
            }
        }.ToList();
    }
    public async Task AdicionarAsync(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }

    public async Task EditarAsync(Pessoa pessoa)
    {
        var index = pessoas.FindIndex(x=>x.Id == pessoa.Id);
        pessoas[index] = pessoa;
    }

    public async Task<Pessoa> ObterPorIdAsync(Guid id)
    {
        var todos = await this.ObterTodosAsync();
        return todos.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
    {
        return pessoas;
    }

    public async Task RemoverAsync(Pessoa pessoa)
    {
        var pess = pessoas.FirstOrDefault(x => x.Id == pessoa.Id);
        pessoas.Remove(pess);
    }
}