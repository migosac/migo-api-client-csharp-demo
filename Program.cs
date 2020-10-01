using System;
using RestSharp;

namespace api_client_csharp_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Migo API Client"));

            string token;
            string ruc;

            Console.WriteLine("Pegar API token");
            token = Console.ReadLine();

            Console.WriteLine("RUC a consultar:");

            while ((ruc = Console.ReadLine()) != null)
            {

                var client = new RestClient();
                client.BaseUrl = new Uri("https://api.migoperu.pe/api/v1");

                var request = new RestRequest("/ruc", Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("ruc", ruc);
                request.AddParameter("token", token);

                IRestResponse<Entidad> response = client.Execute<Entidad>(request);

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

        public class Entidad
        {
            public string Ruc { get; set; }
            public string NombreORazonSocial { get; set; }
            public string EstadoDelContribuyente { get; set; }
            public string CondicionDeDomicilio { get; set; }
            public string Ubigeo { get; set; }
            public string TipoDeVia { get; set; }
            public string NombreDeVia { get; set; }
            public string CodigoDeZona { get; set; }
            public string TipoDeZona { get; set; }
            public string Numero { get; set; }
            public string Interior { get; set; }
            public string Lote { get; set; }
            public string Dpto { get; set; }
            public string Manzana { get; set; }
            public string Kilometro { get; set; }
            public string Distrito { get; set; }
            public string Provincia { get; set; }
            public string Departamento { get; set; }
            public string Direccion { get; set; }
            public DateTime ActualizadoEn { get; set; }
        }
    }
}
