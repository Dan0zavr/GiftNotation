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
        private readonly ContactService _contactService;
        private readonly EventService _eventService;
        private readonly FilterService _filterService;

        private readonly FiltersViewModel _filtersViewModel;


        public FilterWindowService(ContactService contactService, EventService eventService, FilterService filterService, FiltersViewModel filtersViewModel)
        {
            _contactService = contactService;
            _eventService = eventService;
            _filterService = filterService;
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