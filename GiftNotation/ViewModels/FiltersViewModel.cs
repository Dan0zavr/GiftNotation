using GiftNotation.Commands;
using GiftNotation.Commands.GiftCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class FiltersViewModel : ViewModelBase
    {
        private readonly ContactService _contactService;
        private readonly EventService _eventService;
        private readonly FilterService _filterService;

        private string? _selectedMonth;
        private EventType? _selectedEventType;
        private RelpType? _selectedRelpType;

        public ObservableCollection<EventType> EventTypes { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<RelpType> RelpTypes { get; private set; } = new ObservableCollection<RelpType>();
        public ObservableCollection<string> Month { get; private set; } = new ObservableCollection<string>
    {
        "Без фильтра", "Январь", "Февраль", "Март", "Апрель", "Май",
        "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
    };

        public string? SelectedMonth
        {
            get => _selectedMonth;
            set => SetProperty(ref _selectedMonth, value);
        }

        public EventType? SelectedEventType
        {
            get => _selectedEventType;
            set => SetProperty(ref _selectedEventType, value);
        }

        public RelpType? SelectedRelpType
        {
            get => _selectedRelpType;
            set => SetProperty(ref _selectedRelpType, value);
        }

        public ICommand FilterCommand { get; private set; }

        private Action _onFiltersApplied;

        public FiltersViewModel(ContactService contactService, EventService eventService, FilterService filterService)
        {
            _contactService = contactService;
            _eventService = eventService;
            _filterService = filterService;

            // Загрузка типов событий и отношений
            LoadRelpTypes();
            LoadEventTypes();

            // Значения по умолчанию
            SelectedMonth = Month.First();
            SelectedEventType = EventTypes.FirstOrDefault();
            SelectedRelpType = RelpTypes.FirstOrDefault();

            FilterCommand = new FilterCommand(this);
        }

        public void SetFilterAction(Action onFiltersApplied)
        {
            // Присваиваем делегат только если он не null
            _onFiltersApplied = onFiltersApplied ?? throw new ArgumentNullException(nameof(onFiltersApplied), "Delegate cannot be null");
        }

        public void ApplyFilters()
        {
            _onFiltersApplied?.Invoke();
        }

        public async Task LoadRelpTypes()
        {
            RelpTypes.Clear();

            var defaultRelpTypeFilter = new RelpType
            {
                RelpTypeId = 0,
                RelpTypeName = "Без фильтра"
            };

            RelpTypes.Add(defaultRelpTypeFilter);

            var relpTypes = await _contactService.GetAllRelpTypes();
            foreach (var relpType in relpTypes)
            {
                RelpTypes.Add(relpType);
            }
        }

        public async Task LoadEventTypes()
        {
            EventTypes.Clear();

            var defaultEventType = new EventType
            {
                EventTypeId = 0,
                EventTypeName = "Без фильтра"
            };

            EventTypes.Add(defaultEventType);

            var eventTypes = await _eventService.GetEventTypesAsync();
            foreach (var eventType in eventTypes)
            {
                EventTypes.Add(eventType);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
