using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("Cluster");
            var worker = system.ActorOf<WorkerActor>("worker");
            system.WhenTerminated.Wait();
        }
    }

    internal class WorkerActor: UntypedActor
    {
        protected override void OnReceive(object message)
        {
            message.Match()
                .With<string>(s => Console.WriteLine(s));
        }
    }
}
