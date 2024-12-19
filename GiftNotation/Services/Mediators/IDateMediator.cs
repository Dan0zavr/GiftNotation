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
        void UpdateDate(DateTime? newDate);

        public void SetEventDetails(DisplayEventModel eventDetails);

        public void ClearEventDetails();

        public DisplayEventModel GetEventDetails();

    }
}
