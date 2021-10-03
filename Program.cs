using System;
using RestSharp;
using Microsoft.Extensions.Configuration;

namespace ApiClientDemo
{
    class Program
    {
        public static string token;
        static void Main(string[] args)
        {
            IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            token = Config.GetSection("token").Value;

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Elija una opción:");
            Console.WriteLine("1) Consulta RUC");
            Console.WriteLine("2) Consulta DNI");
            Console.WriteLine("3) Consulta Tipo de Cambio");
            Console.WriteLine("4) Salir");
            Console.Write("\r\nSeleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    fetchRuc();
                    return true;
                case "2":
                    fetchDni();
                    return true;
                case "3":
                    fetchExchange();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        private static void fetchRuc()
        {
            string ruc;

            Console.WriteLine("RUC a consultar:");
            ruc = Console.ReadLine();

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.migo.pe/api/v1");

            var request = new RestRequest("/ruc", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("ruc", ruc);
            request.AddParameter("token", token);

            IRestResponse<Entity> response = client.Execute<Entity>(request);

            Console.WriteLine();
            Console.WriteLine("Resultado:");

            if (response.IsSuccessful)
            {
                var content = response.Data;

                Console.WriteLine(response.Data.Ruc);
                Console.WriteLine(response.Data.NombreORazonSocial);
                Console.WriteLine(response.Data.Direccion);
                Console.WriteLine("Estado del Contribuyente: " + response.Data.EstadoDelContribuyente);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            Console.Write("\r\nPresione Enter para regresar al menú principal");
            Console.ReadLine();
        }

        private static void fetchDni()
        {
            string dni;

            Console.WriteLine("DNI a consultar:");
            dni = Console.ReadLine();

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.migo.pe/api/v1");

            var request = new RestRequest("/dni", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("dni", dni);
            request.AddParameter("token", token);

            IRestResponse<Person> response = client.Execute<Person>(request);

            Console.WriteLine();
            Console.WriteLine("Resultado:");

            if (response.IsSuccessful)
            {
                var content = response.Data;

                Console.WriteLine(response.Data.Dni);
                Console.WriteLine("Nombre: " + response.Data.Nombre);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            Console.Write("\r\nPresione Enter para regresar al menú principal");
            Console.ReadLine();
        }

        private static void fetchExchange()
        {
            string fecha;

            Console.WriteLine("Fecha a consultar (YYYY-MM-DD):");
            fecha = Console.ReadLine();

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.migo.pe/api/v1");

            var request = new RestRequest("/exchange/date", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("fecha", fecha);
            request.AddParameter("token", token);

            IRestResponse<Exchange> response = client.Execute<Exchange>(request);

            Console.WriteLine();
            Console.WriteLine("Resultado:");

            if (response.IsSuccessful)
            {
                var content = response.Data;

                Console.WriteLine(response.Data.Fecha);
                Console.WriteLine(response.Data.Moneda);
                Console.WriteLine("Precio de Compra: " + response.Data.PrecioCompra);
                Console.WriteLine("Precio de Venta: " + response.Data.PrecioVenta);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            Console.Write("\r\nPresione Enter para regresar al menú principal");
            Console.ReadLine();
        }
    }
}
