namespace Akka.Ex1.Messages
{
    public class RoomBooked
    {
        public string Number { get; set; }
        public string UserId { get; set; }
        public int Price { get; set; }
    }
}