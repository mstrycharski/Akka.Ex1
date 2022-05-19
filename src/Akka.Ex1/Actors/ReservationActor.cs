using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.Ex1.Extensions;
using Akka.Ex1.Messages;
using Akka.Ex1.Model;

namespace Akka.Ex1.Actors
{
    public class ReservationActor : ReceiveActor
    {
        // internal state
        private readonly List<Room> _rooms = new List<Room>
        {
            new Room("1000", false, 100),
            new Room("1001", true, 80),
            new Room("1002", false, 130),
            new Room("2001", true, 70)
        };

        public ReservationActor()
        {
            Receive<BookRoom>(msg =>
            {
                var roomToBeBooked = _rooms
                    .OrderBy(r => r.Price)
                    .FirstOrDefault(r => r.Price <= msg.MaxPrice && !r.IsBooked);

                IActorRef notificationActor = Context.GetOrCreateActorOf<NotificationActor>("notificationActor");
                IActorRef billingActor = Context.GetOrCreateActorOf<BillingActor>("billingActor");

                if (roomToBeBooked != null)
                {
                    roomToBeBooked.BookRoom();
                    var roomBooked = new RoomBooked
                        { Number = roomToBeBooked.Number, UserId = msg.UserId, Price = roomToBeBooked.Price };
                    notificationActor.Tell(roomBooked);
                    billingActor.Tell(roomBooked);
                }
                else
                {
                    notificationActor.Tell(new RoomBusy { UserId = msg.UserId });
                }
            });
        }
    }
}