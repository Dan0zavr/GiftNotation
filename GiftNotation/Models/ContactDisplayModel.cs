using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Models
{
    public class ContactDisplayModel
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public DateTime? Bday { get; set; }
        public string RelpTypeName { get; set; }
        public string GiftName { get; set; }
    }
}
