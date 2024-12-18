using GiftNotation.Services;
using GiftNotation.ViewModels;
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
        private readonly FiltersViewModel _filtersViewModel;

        public FilterWindowService(FiltersViewModel filtersViewModel)
        {
            _filtersViewModel = filtersViewModel;
        }

        public Filters? CurrentFiltersWindow { get; private set; }

        public void OpenFilterWindow()
        {
            if (CurrentFiltersWindow == null || !CurrentFiltersWindow.IsVisible)
            {
                
                CurrentFiltersWindow = new Filters
                {
                    DataContext = _filtersViewModel
                };

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