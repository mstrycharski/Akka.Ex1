namespace Akka.Ex1.Model
{
    public class Room
    {
        public Room(string number, bool isBooked, int price)
        {
            Number = number;
            IsBooked = isBooked;
            Price = price;
        }

        public void BookRoom()
        {
            IsBooked = true;
        }

        public string Number { get; }
        public bool IsBooked { get; private set; }
        public int Price { get; }
    }
}