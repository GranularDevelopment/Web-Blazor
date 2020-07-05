using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Serverside;
using ServiceProtocol;
using System;
using System.Net;
using Xunit;

namespace TestAPIs
{

    public class ServiceFixture : IDisposable
    {
        private readonly ServiceHandler handler;

        private readonly ProjectServices.ProjectServicesClient projectServicesClient;
        private readonly Channel channel;
        private readonly int port = 50051;
        private readonly string localhost_ip = "127.0.0.1";

        public ServiceFixture()
        {
            // This is the service startup
            handler = new ServiceHandler();
            handler.Startup();
            
            // This is the client startup
            string connection = string.Format("{0}:{1}", localhost_ip, port);
            channel = new Channel(connection, ChannelCredentials.Insecure);
            projectServicesClient = new ProjectServices.ProjectServicesClient(channel);
        }

        public ProjectServices.ProjectServicesClient GetItemClient()
        {
            return projectServicesClient;
        }


        public void Dispose()
        {
            channel.ShutdownAsync().Wait();
            handler.Shutdown();
        }
    }

    public class InitData
    {

        //public static Item orange = new Item { Name = "Oranges" };
        //public static Item fruit = new Item { Name = "Fruit" };
    }

    public class TestItems : IClassFixture<ServiceFixture>
    {
        // TODO: Set this up to run in parallel to detect problems
        // https://xunit.net/docs/running-tests-in-parallel.html

        private readonly ProjectServices.ProjectServicesClient client;

        public TestItems(ServiceFixture fixture)
        {
            client = fixture.GetItemClient();
        }


        [Fact]
        public void AddProject()
        {
        
            //ItemList allItems = client.GetAllItems(new Empty());

            //client.AddNewItem(InitData.fruit);
            //ActionResponse reply = client.AddNewItem(InitData.orange);

            //Assert.Equal(!allItems.Items.Contains(InitData.orange) ? (int)HttpStatusCode.OK : (int)HttpStatusCode.Forbidden, reply.Result);
        }

        [Fact]
        public void GetAllProjectsCheckOne()
        {
            //client.AddNewItem(InitData.orange);
            //ItemList reply = client.GetAllItems(new Empty());
            //Assert.Contains<Item>(InitData.orange, reply.Items);
        }

        [Fact]
        public void GetMatchingProjects()
        {
            //ItemList reply = client.GetMatchingItems(InitData.orange);
            //Assert.Contains<Item>(InitData.orange, reply.Items);
        }
    }
}
