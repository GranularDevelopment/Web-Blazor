using Grpc.Core;
using ServiceProtocol;
using System;

namespace Serverside
{
    public class ServiceHandler : IDisposable
    {
        private Server server;
        private const int Port = 50051;
        public void Startup()
        {
            server = new Server
            {
                Services = { ProjectServices.BindService(new ProjectServicesImpl()) },
                Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
            };
            server.Start();
        }

        public void Shutdown()
        {
            server.ShutdownAsync().Wait();
        }
        public void Dispose()
        {
            Shutdown();
        }
    }

}
