using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels.Factories
{
    public class HomeViewModelFactory : IGiftNotationViewModelFactory<CalendarViewModel>
    {

        public CalendarViewModel CreateViewModel() { 

            return new CalendarViewModel();
        }
    }
}
