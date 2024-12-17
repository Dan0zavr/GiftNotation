using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    public class FilterService
    {
        public string? SelectedMonth { get; set; }
        public EventType? SelectedEventType { get; set; }
        public RelpType? SelectedRelpType { get; set; }

        public event Action FiltersChanged = delegate { };

        public void NotifyFiltersChanged()
        {
            FiltersChanged.Invoke();
        }
    }

}
