using GiftNotation.Models;

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
