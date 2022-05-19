using System;
using Akka.Actor;
using Akka.Ex1.Messages;

namespace Akka.Ex1.Actors
{
    public class BillingActor : ReceiveActor
    {
        public BillingActor()
        {
            Receive<RoomBooked>(msg => Console.WriteLine($"User: '{msg.UserId}' will be billed: ${msg.Price}"));
        }
    }
}