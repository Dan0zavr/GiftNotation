using GiftNotation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    public class FilterWindowService
    {
        public Filters? CurrentFiltersWindow { get; private set; }

        public void OpenFilterWindow()
        {
            if (CurrentFiltersWindow == null || !CurrentFiltersWindow.IsVisible)
            {
                CurrentFiltersWindow = new Filters();
                CurrentFiltersWindow.Show();
            }
        }

        public void CloseFilterWindow()
        {
            if (CurrentFiltersWindow != null && CurrentFiltersWindow.IsVisible)
            {
                CurrentFiltersWindow.Close();
                CurrentFiltersWindow = null;
            }
        }
    }

}
