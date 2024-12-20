using GiftNotation.Models;

namespace GiftNotation.Services.Mediators
{
    public interface IDateMediator
    {
        event Action<DateTime?> DateChanged;
        public event Action<Event> EventDetailsChanged;
        void UpdateDate(DateTime? newDate);

        public void SetEventDetails(Event eventDetails);

        public void ClearEventDetails();

        public Event GetEventDetails();

    }
}
