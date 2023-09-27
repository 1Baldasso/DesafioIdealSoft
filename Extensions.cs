using System;
using Humanizer;
namespace DesafioIdealSoft;

public static class Extensions
{
    public static string MaskTelefone(this string telefone)
    {
        if (telefone.Length == 10)
            return telefone.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(9, "-");
        else if (telefone.Length == 11)
            return telefone.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(9, "-");
        else
            throw new ArgumentException("Telefone inválido");
    }

    public static string UnmaskTelefone(this string telefone)
    {
        return telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
    }

    public static PessoaVM ToPessoaVM(this Pessoa pessoa)
    {
        return new PessoaVM
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome.Titleize(),
            Sobrenome = pessoa.Sobrenome.Titleize(),
            Telefone = pessoa.Telefone.MaskTelefone()
        };
    }

    public static Pessoa ToPessoa(this PessoaVM pessoa)
    {
        return new Pessoa
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome.Titleize(),
            Sobrenome = pessoa.Sobrenome.Titleize(),
            Telefone = pessoa.Telefone.UnmaskTelefone()
        };
    }
}
