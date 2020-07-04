using Grpc.Core;
using Models;
using ServiceProtocol;
using System.Net;
using System.Threading.Tasks;

namespace Serverside
{
    public class TradeServiceImpl : TradeService.TradeServiceBase
    {
        // Server side handler of the SayHello RPC
        public override Task<ActionResponse> CreateTrade(Trade request, ServerCallContext context)
        {
            using (DataContext db = new DataContext())
            {
                bool created = db.Database.EnsureCreated();
                //Console.WriteLine("Database was created (true), or existing (false): {0}", created);
                try
                {
                    db.Add(request);
                    db.SaveChanges();
                    return Task.FromResult(new ActionResponse { Result = (int)HttpStatusCode.OK });
                }
                catch
                {
                    return Task.FromResult(new ActionResponse { Result = (int)HttpStatusCode.Forbidden });
                }
            }
        }
    }
}