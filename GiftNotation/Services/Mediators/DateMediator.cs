using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services.Mediators
{
    public class DateMediator : IDateMediator
    {
        public event Action<DateTime?> DateChanged;
        public event Action<Event> EventDetailsChanged; // Добавляем событие для передачи данных о событии

        private Event _currentEventDetails;

        public void UpdateDate(DateTime? newDate)
        {
            DateChanged?.Invoke(newDate);

            // Опционально можно здесь вызывать EventDetailsChanged, если нужно обновить данные для выбранной даты
            EventDetailsChanged?.Invoke(_currentEventDetails);
        }

        public void SetEventDetails(Event eventDetails)
        {
            _currentEventDetails = eventDetails;
            // Вызываем событие для передачи данных в ViewModel или окно
            EventDetailsChanged?.Invoke(_currentEventDetails);
        }

        public void ClearEventDetails()
        {
            _currentEventDetails = null;
            EventDetailsChanged?.Invoke(null);  // Очищаем данные в UI
        }

        public Event GetEventDetails()
        {
            return _currentEventDetails;
        }
    }

}
