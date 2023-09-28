using DesafioIdealSoft.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Microsoft.Extensions.Http;
using System;

namespace DesafioIdealSoft
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //services.AddScoped<IPessoaRepository, MockPessoaRepository>();
            services.AddScoped<IPessoaRepository, ApiPessoaRepository>();
            services.AddSingleton<PaginaPrincipal>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<PaginaPrincipal>().Show();
        }
    }
}
