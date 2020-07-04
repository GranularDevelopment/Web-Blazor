using Serverside;
using System.Threading;

namespace StubServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (ServiceHandler server = new ServiceHandler())
            {
                server.Startup();
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
