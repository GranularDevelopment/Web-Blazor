using Grpc.Core;
using ServiceProtocol;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace XYZ.Data
{
    public class WebService 
    {
        private readonly ProjectServices.ProjectServicesClient projectServicesClient;
        
        public ProjectServices.ProjectServicesClient GetProjectServicesClient()
        {
            return projectServicesClient;
        }


        private readonly Channel channel;
        private readonly int port = 50051;
        private readonly string localhost_ip = "127.0.0.1";
        public WebService()
        {
               // This is the client startup
            string connection = string.Format("{0}:{1}", localhost_ip, port);
            channel = new Channel(connection, ChannelCredentials.Insecure);
            projectServicesClient = new ProjectServices.ProjectServicesClient(channel);
        }
    }
}
