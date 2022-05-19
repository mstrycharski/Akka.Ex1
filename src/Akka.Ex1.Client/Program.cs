using System;
using Akka.Actor;
using Akka.Ex1.Actors;
using Akka.Ex1.Messages;

namespace Akka.Ex1.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ActorSystem system = ActorSystem.Create("mySystem");
            IActorRef reservationActor = system.ActorOf<ReservationActor>("reservationActor");
            reservationActor.Tell(new BookRoom { UserId = "1", MaxPrice = 30 });
            reservationActor.Tell(new BookRoom { UserId = "2", MaxPrice = 70 });
            reservationActor.Tell(new BookRoom { UserId = "3", MaxPrice = 150 });
            reservationActor.Tell(new BookRoom { UserId = "4", MaxPrice = 130 });
            reservationActor.Tell(new BookRoom { UserId = "5", MaxPrice = 170 });

            Console.ReadKey();
        }
    }
}
