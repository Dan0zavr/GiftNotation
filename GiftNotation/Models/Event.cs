using System.Diagnostics.CodeAnalysis;

namespace GiftNotation.Models;

public class Event
{
    public int EventId { get; set; }
    [NotNull]
    public string EventName { get; set; }
    [NotNull]
    public DateTime EventDate { get; set; }

    public int? EventTypeId { get; set; }
    public EventType EventType { get; set; }

    public ICollection<EventContact> EventContacts { get; set; }
    public ICollection<GiftEvent> GiftEvents { get; set; }
}

