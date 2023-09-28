using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioIdealSoft.DataAccess;

public class MockPessoaRepository : IPessoaRepository
{
    private List<Pessoa> pessoas;
    public MockPessoaRepository()
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
    public void Adicionar(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }

    public void Editar(Pessoa pessoa)
    {
        var index = pessoas.FindIndex(x=>x.Id == pessoa.Id);
        pessoas[index] = pessoa;
    }

    public Pessoa ObterPorId(Guid id)
    {
        var todos = this.ObterTodos();
        return todos.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Pessoa> ObterTodos()
    {
        return pessoas;
    }

    public void Remover(Pessoa pessoa)
    {
        var pess = pessoas.FirstOrDefault(x => x.Id == pessoa.Id);
        pessoas.Remove(pess);
    }
}