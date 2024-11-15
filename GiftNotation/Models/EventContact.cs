﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
