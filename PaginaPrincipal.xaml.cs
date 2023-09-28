using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using DesafioIdealSoft.DataAccess;
using System.Linq;
using System;

namespace DesafioIdealSoft
{
    public partial class PaginaPrincipal : Window
    {
        public ObservableCollection<PessoaVM> PessoasList { get; set; }
        private readonly IPessoaRepository _pessoaRepository;
        public PaginaPrincipal(IPessoaRepository repository)
            : this()
        {
            _pessoaRepository = repository;
            PessoasList = new ObservableCollection<PessoaVM>(repository.ObterTodos()
                .Select(x=> x.ToPessoaVM()));
        }
        public PaginaPrincipal()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void Editar_Click(object sender ,RoutedEventArgs args)
        {
            var pessoa = (sender as Button).DataContext as PessoaVM;
            var editarPessoa = new PaginaPessoaCommand(pessoa.Id, _pessoaRepository);
            editarPessoa.Closed += async (sender, args) =>
            {
                var pessoas = _pessoaRepository.ObterTodos();
                PessoasList = new ObservableCollection<PessoaVM>(pessoas.Select(x => x.ToPessoaVM()));
                DataGrid1.ItemsSource = PessoasList;
            };
            editarPessoa.ShowDialog();
        }
        public void Remover_Click(object sender ,RoutedEventArgs args)
        {
            var pessoa = (sender as Button).DataContext as PessoaVM;
            _pessoaRepository.Remover(pessoa.ToPessoa());
            var pessoas = _pessoaRepository.ObterTodos();
            PessoasList = new ObservableCollection<PessoaVM>(pessoas.Select(x => x.ToPessoaVM()));
            DataGrid1.ItemsSource = PessoasList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var editarPessoa = new PaginaPessoaCommand(_pessoaRepository);
            editarPessoa.Closed += async (sender, args) =>
            {
                var pessoas = _pessoaRepository.ObterTodos();
                PessoasList = new ObservableCollection<PessoaVM>(pessoas.Select(x => x.ToPessoaVM()));
                DataGrid1.ItemsSource = PessoasList;
            };
            editarPessoa.ShowDialog();
        }
    }
}
