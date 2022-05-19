using System;
using Akka.Actor;
using Akka.Ex1.Messages;

namespace Akka.Ex1.Actors
{
    public class NotificationActor : ReceiveActor
    {
        public NotificationActor()
        {
            Receive<RoomBooked>(msg => Console.WriteLine($"Room: '{msg.Number}' booked for '{msg.UserId}'!"));
            Receive<RoomBusy>(msg => Console.WriteLine($"No available room for User: '{msg.UserId}'!"));
        }
    }
}