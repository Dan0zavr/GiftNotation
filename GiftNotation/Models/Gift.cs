using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Models
{
    public class Gift
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; } = null;
        public string? url { get; set; }
        public int price { get; set; }
        public string? picturePath { get; set; }
        public int statusId { get; set; }
    }
}
