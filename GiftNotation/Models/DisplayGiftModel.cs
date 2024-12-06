using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GiftNotation.Models
{
    public class DisplayGiftModel
    {
        public int GiftId { get; set; }
        public string? GiftName { get; set; } = string.Empty; 
        public string? Description { get; set; } = string.Empty;
        public double Price { get; set; }  = 0.0;
        public string? GiftPic { get; set; } = string.Empty;
        public string? Url { get; set; } = string.Empty;
        public string? ContactName { get; set; } = string.Empty;
        public string? EventName { get; set; } = string.Empty;
        public string? StatusName { get; set; } = string.Empty;

    }
}
