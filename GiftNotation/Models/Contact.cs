using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string? name { get; set; }

        public DateTime? date { get; set; }

        public int relationshipId { get; set; }


    }
}
