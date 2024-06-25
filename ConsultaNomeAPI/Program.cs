using ConsultaNomeAPI.BuscaDadosPessoa;
using ConsultaNomeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaNomeAPI
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Definindo o Nome para consulta
            string name = "JOSE";
            string localidade = "BR";
            string sexo = "M";

            try
            {
                // Chama método para busca de nome
                List<Pessoa> pessoas = await ObterDadosPessoa.ObterDadosPessoaAsync(name, localidade, sexo);

                if (pessoas != null)
                {
                    Console.WriteLine("Resposta da API:");
                    foreach (var pessoa in pessoas)
                    {
                        Console.WriteLine($"Localidade: {pessoa.Localidade}");
                        Console.WriteLine($"Sexo: {pessoa.Sexo}");

                        foreach (var res in pessoa.Res)
                        {
                            Console.WriteLine($"Nome: {res.Nome}");
                            Console.WriteLine($"Frequência: {res.Frequencia}");
                            Console.WriteLine($"Ranking: {res.Ranking}");
                            Console.WriteLine("---------------");
                        }
                    }
                }
         
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
