﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;

public class Event
{
    public int EventId { get; set; }
    public string? EventName { get; set; }
    public DateTime? EventDate { get; set; }

    public int? EventTypeId { get; set; }
    public EventType EventType { get; set; }

    public ICollection<EventContact> EventContacts { get; set; }
    public ICollection<GiftEvent> GiftEvents { get; set; }
}

