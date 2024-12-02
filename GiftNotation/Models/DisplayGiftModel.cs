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
        public string? GiftName { get; set; }    
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? GiftPic {  get; set; }
        public string? Url { get; set; }
        public string? ContactName { get; set; }
        public string? EventName { get; set; }
        public string? StatusName { get; set; }

    }
}
