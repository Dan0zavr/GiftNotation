using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Models;

[Index(nameof(RelpTypeName), IsUnique = true)]
public class RelpType
{
    public int RelpTypeId { get; set; }
    public string RelpTypeName { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}

