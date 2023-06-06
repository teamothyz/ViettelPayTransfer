namespace VTPLibrary
{
    public class MyProxy
    {
        public string Host { get; set; } = null!;

        public int Port { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public MyProxy(string host, int port)
        {
            Host = host;
            Port = port;
            Username = null;
            Password = null;
        }

        public MyProxy(string host, int port, string user, string password)
        {
            Host = host;
            Port = port;
            Username = user;
            Password = password;
        }
    }
}
