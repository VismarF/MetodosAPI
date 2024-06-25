using ConsultaNomeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsultaNomeAPI.BuscaDadosPessoa
{
    public class ObterDadosPessoa
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Pessoa>> ObterDadosPessoaAsync(string name, string localidade, string sexo)
        {
            try
            {
                // Url da API com nome fornecido
                string url = $"https://servicodados.ibge.gov.br/api/v2/censos/nomes/ranking?name={name}&sexo={sexo}&localidade={localidade}";



                // Fazendo requisição com o método GET
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Ler conteúdo da resposta
                string responseBody = await response.Content.ReadAsStringAsync();

                // Desserializar o JSON para uma lista de objetos Pessoa
                List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(responseBody);
                return pessoas;
            }
            catch (HttpRequestException e)
            {
                // Trata erros de requisição HTTP
                Console.WriteLine($"Erro na requisição: {e.Message}");
                return null;
            }
        }
    }
}
