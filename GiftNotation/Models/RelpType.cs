using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;

public class RelpType
{
    public int RelpTypeId { get; set; }
    public string RelpTypeName { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}

