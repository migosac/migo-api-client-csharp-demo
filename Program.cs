using System;
using RestSharp;

namespace api_client_csharp_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string token;
            string ruc;

            Console.WriteLine("Pegar API token");
            token = Console.ReadLine();

            Console.WriteLine("RUC a consultar:");

            while ((ruc = Console.ReadLine()) != null)
            {

                var client = new RestClient();
                client.BaseUrl = new Uri("https://api.migo.pe/api/v1");

                var request = new RestRequest("/ruc", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("ruc", ruc);
                request.AddParameter("token", token);

                IRestResponse<Entity> response = client.Execute<Entity>(request);

                Console.WriteLine();
                Console.WriteLine("Respuesta:");

                if (response.IsSuccessful)
                {
                    var content = response.Data;

                    //Iterar las propiedades del objeto
                    Console.WriteLine(response.Data.Ruc);
                    Console.WriteLine(response.Data.NombreORazonSocial);
                    Console.WriteLine(response.Data.Direccion);
                    Console.WriteLine(response.Data.ActualizadoEn);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }

                Console.WriteLine();
                Console.WriteLine("RUC a consultar:");
            }
        }
    }
}
