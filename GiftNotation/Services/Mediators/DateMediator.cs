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

        private DisplayEventModel _currentEventDetails;

        public void UpdateDate(DateTime? newDate)
        {
            DateChanged?.Invoke(newDate);
        }

        public void SetEventDetails(DisplayEventModel eventDetails)
        {
            _currentEventDetails = eventDetails;
            // Логика для передачи данных о событии в окно добавления (например, через событие или напрямую в ViewModel)
        }

        public void ClearEventDetails()
        {
            _currentEventDetails = null;
            // Очистить данные события в форме
        }

        public DisplayEventModel GetEventDetails()
        {
            return _currentEventDetails;
        }
    }
}
