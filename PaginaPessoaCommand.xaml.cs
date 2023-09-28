using DesafioIdealSoft.DataAccess;
using System;
using System.Windows;

namespace DesafioIdealSoft
{
    /// <summary>
    /// Lógica interna para PaginaEditar.xaml
    /// </summary>
    public partial class PaginaPessoaCommand : Window
    {
        private readonly PessoaVM _pessoa;
        private readonly IPessoaRepository _repository;
        public PaginaPessoaCommand(IPessoaRepository repository)
            : this()
        {
            _repository = repository;
            _pessoa = new PessoaVM
            {
                Id = Guid.NewGuid()
            };
            DataContext = _pessoa;
            btnConfirmar.Content = "Criar";
        }
        public PaginaPessoaCommand(Guid id, IPessoaRepository repository)
            : this()
        {
            _repository = repository;
            _pessoa = repository.ObterPorId(id).ToPessoaVM();
            DataContext = _pessoa;
            btnConfirmar.Content = "Editar";
        }
        private PaginaPessoaCommand()
        {
            InitializeComponent();
        }

        public void btnConfirmar_Click(object sender, RoutedEventArgs args)
        {
            _pessoa.Nome = txtNome.Text;   
            _pessoa.Sobrenome = txtSobrenome.Text;
            _pessoa.Telefone = txtTelefone.Text;
            if(btnConfirmar.Content.ToString() == "Editar")
                _repository.Editar(_pessoa.ToPessoa());
            else
                _repository.Adicionar(_pessoa.ToPessoa());
            Close();
        }
    }
}
