using GiftNotation.Commands;
using GiftNotation.Commands.EventCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Views;
using GiftNotation.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using GiftNotation.Services.Mediators;

namespace GiftNotation.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayEventModel> _events;
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private FiltersViewModel? _filtersViewModel;
        private readonly FilterWindowService _filterWindowService;
        private readonly IDateMediator _dateMediator;

        public DisplayEventModel selectedEvent;
        private Window? _filtersWindow;

        private bool _isFiltersWindowVisible;

        public bool IsFiltersWindowVisible
        {
            get => _isFiltersWindowVisible;
            set => SetProperty(ref _isFiltersWindowVisible, value);
        }

        public DisplayEventModel SelectedEvent
        {
            get => selectedEvent;
            set
            {
                SetProperty(ref selectedEvent, value);
                ((DeleteEventCommand)DeleteEventCommand).RaiseCanExecuteChanged();
                ((OpenChangeEventCommand)OpenChangeEventCommand).RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<DisplayEventModel> Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        public ICommand DeleteEventCommand { get; set; }
        public ICommand OpenAddEventCommand { get; set; }
        public ICommand OpenChangeEventCommand { get; set; }
        public ICommand OpenCloseFilterCommand { get; set; }

        public EventViewModel(EventService eventService, ContactService contactService, FilterWindowService filterWindowService, 
            FiltersViewModel filtersViewModel, GiftService giftService, IDateMediator dateMediator)
        {
            _eventService = eventService;
            _contactService = contactService;
            _filterWindowService = filterWindowService;
            _filtersViewModel = filtersViewModel;
            _giftService = giftService;

            // Передаем делегат фильтрации в FiltersViewModel
            _filtersViewModel.SetFilterAction(async () =>
            {
                await ApplyFilters();
            });

            DeleteEventCommand = new DeleteEventCommand(this, _eventService);
            OpenAddEventCommand = new OpenAddEventCommand(eventService, this, _contactService, _giftService, dateMediator);
            OpenChangeEventCommand = new OpenChangeEventCommand(this, _eventService, _contactService);
            OpenCloseFilterCommand = new OpenCloseFilterCommand(_filterWindowService);

            LoadEvents();
            
        }

        public async void LoadEvents()
        {
            await ApplyFilters();
        }

        public async Task ApplyFilters()
        {
            if (_filtersViewModel == null)
                return;

            // Получаем текущие значения фильтров
            string month = _filtersViewModel.SelectedMonth ?? "Без фильтра";
            string eventType = _filtersViewModel.SelectedEventType?.EventTypeName ?? "Без фильтра";
            string relpType = _filtersViewModel.SelectedRelpType?.RelpTypeName ?? "Без фильтра";

            // Вызываем сервис для фильтрации
            var filteredEvents = await _eventService.FilterEvents(month, eventType, relpType);

            // Обновляем коллекцию
            Events = new ObservableCollection<DisplayEventModel>(filteredEvents);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
