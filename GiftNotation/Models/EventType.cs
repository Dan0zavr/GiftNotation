using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;

public class EventType
{
    public int EventTypeId { get; set; }
    public string EventTypeName { get; set; }
    public ICollection<Event> Events { get; set; }
}

