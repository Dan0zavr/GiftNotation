using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftNotation.Models;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata;
using GiftNotation.State.Navigators;
using GiftNotation.Services;
using GiftNotation.Views;
using GiftNotation.Services.Mediators;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GiftNotation.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly ContactService _contactService;
        private readonly EventService _eventService;
        private readonly EventViewModel _eventViewModel;
        private readonly GiftService _giftService;

        private readonly IDateMediator _dateMediator;


        private DateTime? _selectedDate;


        private ObservableCollection<DateTime> events = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> Events 
        { 
            get => events;
            set => SetProperty(ref events, value);
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (SetProperty(ref _selectedDate, value))
                {
                    _dateMediator.UpdateDate(value);
                    OpenEventDetails(SelectedDate);
                }
            }
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand OpenEventDetailsCommand { get; }

        public CalendarViewModel(EventService eventService, ContactService contactService, EventViewModel eventViewModel, GiftService giftService, IDateMediator dateMediator)
        {
            _contactService = contactService;
            _eventService = eventService;
            _eventViewModel = eventViewModel;
            _giftService = giftService;
            _dateMediator = dateMediator;
            LoadEvents();
            _dateMediator.DateChanged += OnDateChanged;
        }

        private async void LoadEvents()
        {
            var events = await _eventService.GetAllEventDates();
            Events = new ObservableCollection<DateTime>(events.Where(d => d.Date >= DateTime.Now.Date));
        }

        private void OnDateChanged(DateTime? newDate)
        {
            if (newDate.HasValue)
            {
                // Логика обновления отображения, например, перезагрузка событий на выбранной дате
                LoadEvents();
            }
        }

        private void OpenEventDetails(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                // Передаем выбранную дату в AddEventViewModel через конструктор
                var viewModel = new AddEventViewModel(_eventService, _eventViewModel, _contactService, _giftService, _dateMediator);
                viewModel.EventDate = selectedDate.Value;
                var eventDetailsWindow = new EventDetailsWindow
                {
                    DataContext = viewModel,
                };
                eventDetailsWindow.Show();
            }
        }

    }
}
    
