using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Models
{
    public class DisplayContactModel
    {
        public int ContactId { get; set; }
        public string? ContactName { get; set; } = string.Empty;
        public DateTime? Bday { get; set; } = null;
        public string? RelpTypeName { get; set; } = string.Empty;
        public ObservableCollection<Gifts?> SelectedGifts { get; set; } = null!;


    }
}
