using System;
using System.Runtime.InteropServices;
using System.Security;
using Tachan.WS.ConsoleClient.Model;
using Tachan.WS.Tools;

namespace Tachan.WS.ConsoleClient
{
    internal static class Program
    {
        #region Fields

        private static string BaseUri = string.Empty;
        private static string token = string.Empty;

        #endregion Fields

        #region Methods

        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString GetPassword()
        {
            Console.WriteLine("Password:");
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }

        private static void Add()
        {
            Console.WriteLine("Inserta el ID de la película");
            var movieId = Console.ReadLine();
            while (string.IsNullOrEmpty(movieId))
            {
                movieId = Console.ReadLine();
            }
            Console.WriteLine("Inserta el ID del album");
            var albumId = Console.ReadLine();
            while (string.IsNullOrEmpty(albumId))
            {
                albumId = Console.ReadLine();
            }

            Verification ver = new Verification() { albumId = albumId, movieId = movieId };

            ServerVerification verification = Client.CreateClient()
                    .SetMimeType("application/json")
                    .SetUri(BaseUri)
                    .AddAuthorizationHeader("", token)
                    .HttpPost<ServerVerification, Verification>("secure/verification", ver)
                    .Result;

            if (verification == null)
            {
                Console.WriteLine($"Verificación errónea, vuelva a intentarlo");
                Add();
            }

            Console.WriteLine($"Verificación con id: [{verification._id}] incluida");
        }

        private static void Configuration()
        {
#if DEBUG
            var baseUri = "http://localhost:8080/";
#else
            Console.WriteLine("Introduzca la URL de conexión al servicio");
            var baseUri = Console.ReadLine();
            while (string.IsNullOrEmpty(baseUri))
            {
                baseUri = Console.ReadLine();
            }
#endif
            BaseUri = baseUri;
        }

        private static void Del()
        {
            Console.WriteLine("Inserta el ID de la verificación");
            var verificationId = Console.ReadLine();
            while (string.IsNullOrEmpty(verificationId))
            {
                verificationId = Console.ReadLine();
            }

            ServerVerification verification = Client.CreateClient()
                .SetMimeType("application/json")
                .SetUri(BaseUri)
                .AddAuthorizationHeader("", token)
                .HttpDel<ServerVerification>($"secure/verification/{verificationId}")
                .Result;

            if (verification == null)
            {
                Console.WriteLine($"Verificación errónea, vuelva a intentarlo");
                Del();
            }

            Console.WriteLine($"Verificación con id: [{verification._id}] eliminada");
            Console.WriteLine($"{verification}");
        }

        private static string GetUser()
        {
            var user = Console.ReadLine();
            while (string.IsNullOrEmpty(user))
            {
                Console.WriteLine("Introduzca un email válido");
                user = Console.ReadLine();
            }

            return user;
        }

        private static void Login()
        {
            while (true)
            {
                Console.WriteLine("Email:");
#if DEBUG
                var user = "uo232562@uniovi.es";
                var password = "meat";
#else
                var user = GetUser();
                var password = GetPassword().ConvertToUnsecureString();
#endif

                var authorize = new AuthUser(user, password);
                try
                {
                    token = Client.CreateClient().SetMimeType("application/json").SetUri(BaseUri)
                        .HttpPost<dynamic, AuthUser>("token", authorize)?.Result?.token?.ToString();

                    if (!string.IsNullOrEmpty(token))
                        break;
                    else
                        Console.WriteLine("Login incorrecto!!");
                }
                catch (UriFormatException ex)
                {
                    Console.WriteLine("URL no válida: (ejemplo: http://<IP>/)");
                }
            }
        }

        private static void Main(string[] args)
        {
            Welcome();

            Configuration();

            Login();

            Operations();

            Console.ReadLine();
        }

        private static void Operations()
        {
            Console.WriteLine("Bienvenido a la consola de administración");
            Console.WriteLine("Introduzca 1 para comenzar con la inclusión de elementos");
            Console.WriteLine("Introduzca 2 para comenzar con la actualización de elementos");
            Console.WriteLine("Introduzca 3 para comenzar con la eliminación de elementos");
            Console.WriteLine("Introduzca 4 para cambiar de usuario");
            Console.WriteLine("Introduzca exit para abandonar la aplicación");
            while (true)
            {
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Add();
                        break;

                    case "2":
                        Put();
                        break;

                    case "3":
                        Del();
                        break;

                    case "4":
                        Login();
                        break;

                    case "exit":
                        Console.WriteLine("Hasta la próxima!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida (1,2,3,4)");
                        break;
                }

                if (option == "exit")
                    break;
            }
        }

        private static void Put()
        {
            Console.WriteLine("Inserta el ID de la verificación");
            var verificationId = Console.ReadLine();
            while (string.IsNullOrEmpty(verificationId))
            {
                verificationId = Console.ReadLine();
            }
            Console.WriteLine("Inserta el ID de la película");
            var movieId = Console.ReadLine();
            while (string.IsNullOrEmpty(movieId))
            {
                movieId = Console.ReadLine();
            }
            Console.WriteLine("Inserta el ID del album");
            var albumId = Console.ReadLine();
            while (string.IsNullOrEmpty(albumId))
            {
                albumId = Console.ReadLine();
            }

            Verification ver = new Verification() { albumId = albumId, movieId = movieId };

            ServerVerification verification = Client.CreateClient()
                .SetMimeType("application/json")
                .SetUri(BaseUri)
                .AddAuthorizationHeader("", token)
                .HttpPut<ServerVerification, Verification>($"secure/verification/{verificationId}", ver)
                .Result;

            if (verification == null)
            {
                Console.WriteLine($"Verificación errónea, vuelva a intentarlo");
                Put();
            }

            Console.WriteLine($"Verificación con id: [{verification._id}] actualizada");
            Console.WriteLine($"{verification}");
        }

        private static void Welcome()
        {
            Console.WriteLine("#############################################################");
            Console.WriteLine("###  Bienvenido a la consola de administración de Tachan  ###");
            Console.WriteLine("###################   Versión 1.0    ########################");
            Console.WriteLine("#############################################################");
        }

        #endregion Methods
    }
}