using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;
public class Status
{
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public ICollection<Gifts> Gifts { get; set; }
}

