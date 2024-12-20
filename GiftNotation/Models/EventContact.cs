namespace GiftNotation.Models
{

    public class EventContact
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }

}
