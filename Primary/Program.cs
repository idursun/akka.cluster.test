using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;

namespace Primary
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("Cluster");
            var router = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "broadcaster");

            while (Console.ReadLine() != "q")
            {
                var routees = router.Ask<Routees>(new GetRoutees()).Result;
                var consistentHashableEnvelope = new ConsistentHashableEnvelope(Guid.NewGuid().ToString(), Guid.NewGuid());
                router.Tell(consistentHashableEnvelope);
                Console.WriteLine("sending {0} routees", routees.Members.Count());
            }
        }
    }
}
