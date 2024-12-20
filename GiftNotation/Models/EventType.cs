using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;

[Index(nameof(EventTypeName), IsUnique = true)]
public class EventType
{
    public int EventTypeId { get; set; }
    public string EventTypeName { get; set; }
    public ICollection<Event> Events { get; set; }
}

