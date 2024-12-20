using System.Collections.ObjectModel;

namespace GiftNotation.Models
{
    public class DisplayEventModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string? EventTypeName { get; set; }
        public ObservableCollection<Contact?> ContactsOnEvent { get; set; }
    }
}
