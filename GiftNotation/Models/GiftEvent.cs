namespace GiftNotation.Models
{

    public class GiftEvent
    {
        public int GiftId { get; set; }
        public Gifts Gift { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }

}
