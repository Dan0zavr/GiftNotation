using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
