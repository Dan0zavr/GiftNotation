namespace GiftNotation.Models
{

    public class GiftContact
    {
        public int GiftId { get; set; }
        public Gifts Gift { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }

}
