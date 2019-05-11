using System;
using RestSharp;

namespace api_client_csharp_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("API Client Example"));
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.migoperu.pe/api/v1");

            var request = new RestRequest("/ruc", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("ruc", "20603274742");
            request.AddParameter("token", "Ingrese su API Token aquí");

            // Usar este bloque si solo quiere ver los valores devueltos
            // IRestResponse responseData = client.Execute(request);
            // System.Console.WriteLine(responseData.Content);

            IRestResponse<Entidad> response = client.Execute<Entidad>(request);

            if (response.IsSuccessful)
            {
                var content = response.Data;

                //Iterar las propiedades del objeto
                Console.WriteLine(response.Data.Ruc);
                Console.WriteLine(response.Data.NombreORazonSocial);
                Console.WriteLine(response.Data.Direccion);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.ReadKey();
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
        }
    }
}
