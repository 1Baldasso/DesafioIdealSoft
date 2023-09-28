using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioIdealSoft.DataAccess;

internal class ApiPessoaRepository : IPessoaRepository
{
    private const string API_URL = "https://desafio-idealsoft.azurewebsites.net";
    private readonly HttpClient _httpClient;
    public ApiPessoaRepository()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(API_URL),
            Timeout = TimeSpan.FromSeconds(10)            
        };
    }
    public void Adicionar(Pessoa pessoa)
    {
        string json = JsonConvert.SerializeObject(pessoa);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync("/pessoas", content).Result;
        if (!response.IsSuccessStatusCode)
            throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public void Editar(Pessoa pessoa)
    {
        string json = JsonConvert.SerializeObject(new { Pessoa = pessoa });
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        _httpClient.PutAsync($"/pessoas/{pessoa.Id}", content).Wait();
    }

    public Pessoa ObterPorId(Guid id)
    {
        var response = _httpClient.GetAsync($"/pessoas/{id}").Result;
        var json = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Pessoa>(json);
    }

    public IEnumerable<Pessoa> ObterTodos()
    {
        var response = _httpClient.GetAsync($"pessoas").Result;
        var json = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<IEnumerable<Pessoa>>(json);
    }

    public void Remover(Pessoa pessoa)
    {
        _httpClient.DeleteAsync($"/pessoas/{pessoa.Id}").Wait();
    }
}
