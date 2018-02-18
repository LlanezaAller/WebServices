namespace Tachan.WS.ConsoleClient.Model
{
    internal class AuthUser
    {
        public AuthUser(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}