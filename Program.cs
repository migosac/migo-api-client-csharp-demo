using System;
using RestSharp;

namespace api_client_csharp_example
{
    class Program
    {
        public static string token;
        static void Main(string[] args)
        {

            Console.WriteLine("Ingresar token");
            token = Console.ReadLine();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Elija una opción:");
            Console.WriteLine("1) Consulta RUC");
            Console.WriteLine("2) Consulta DNI");
            Console.WriteLine("3) Salir");
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

                //Iterar las propiedades del objeto
                Console.WriteLine(response.Data.Ruc);
                Console.WriteLine(response.Data.NombreORazonSocial);
                Console.WriteLine(response.Data.Direccion);
                Console.WriteLine(response.Data.EstadoDelContribuyente);
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

                //Iterar las propiedades del objeto
                Console.WriteLine(response.Data.Dni);
                Console.WriteLine(response.Data.Nombre);
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
