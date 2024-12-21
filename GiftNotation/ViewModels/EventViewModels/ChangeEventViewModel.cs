using GiftNotation.Commands.EventCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class ChangeEventViewModel : ViewModelBase
    {
        private int _eventId;
        private string _eventName;
        private DateTime _eventDate;
        private string _selectedEventTypeName;

        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly EventViewModel _eventViewModel;
        private DisplayEventModel _selectedEvent;
        private EventType _selectedEventType;

        private AddContactOnEventOnChangeCommand _addContactOnEventCommand;
        private Contact _selectedContact;

        public ObservableCollection<EventType> EventTypes { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<Contact> Contacts { get; private set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> ContactsOnEvent { get; private set; } = new ObservableCollection<Contact>();

        private string _rawEventDateInput;  // Для привязки к TextBox
        private bool _isEventDateValid;

        // Валидация даты
        public bool IsEventDateValid
        {
            get => _isEventDateValid;
            set => SetProperty(ref _isEventDateValid, value);
        }

        public string RawEventDateInput
        {
            get => _rawEventDateInput;
            set
            {
                if (SetProperty(ref _rawEventDateInput, value))
                {
                    // Преобразуем строку в DateTime при изменении
                    if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        EventDate = parsedDate;
                        IsEventDateValid = true;
                    }
                    else
                    {
                        IsEventDateValid = false;
                    }
                }
            }
        }

        public DateTime EventDate
        {
            get => _eventDate;
            set
            {
                if (SetProperty(ref _eventDate, value))
                {
                    // Когда дата изменяется, обновляем RawEventDateInput
                    RawEventDateInput = value.ToString("dd.MM.yyyy");
                    IsEventDateValid = true;
                }
            }
        }

        public Contact SelectedContactOnEvent { get; set; }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (SetProperty(ref _selectedContact, value))
                {
                    // Уведомляем команду, что условие для CanExecute могло измениться
                    ((AddContactOnEventOnChangeCommand)_addContactOnEventCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public DeleteContactFromEventOnChangeCommand DeleteContactFromEventOnChangeCommand { get; }
        public ICommand AddContactOnEventOnChangeCommand => _addContactOnEventCommand;

        public int EventId => _eventId;

        private bool _isEventNameValid = true; // По умолчанию валидно
        public bool IsEventNameValid
        {
            get => _isEventNameValid;
            set => SetProperty(ref _isEventNameValid, value);
        }

        public string EventName
        {
            get => _eventName;
            set
            {
                if (SetProperty(ref _eventName, value))
                {
                    IsEventNameValid = !string.IsNullOrWhiteSpace(_eventName);
                }
            }
        }

        public EventType? SelectedEventType
        {
            get => _selectedEventType;
            set => SetProperty(ref _selectedEventType, value);
        }

        public string SelectedEventTypeName
        {
            get => _selectedEventTypeName;
            set => SetProperty(ref _selectedEventTypeName, value);
        }

        public ChangeEventCommand ChangeEventCommand { get; set; }

        public ChangeEventViewModel(EventService eventService, EventViewModel eventViewModel, ContactService contactService)
        {
            _contactService = contactService;
            _eventService = eventService;
            _eventViewModel = eventViewModel;
            ChangeEventCommand = new ChangeEventCommand(eventService, this, _eventViewModel);
            DeleteContactFromEventOnChangeCommand = new DeleteContactFromEventOnChangeCommand(this, _contactService);
            _addContactOnEventCommand = new AddContactOnEventOnChangeCommand(this);
            LoadData();
            LoadContactsOnEvent();
            LoadContacts();
            LoadEventTypes();
        }

        private async void LoadData()
        {
            var events = await _eventService.GetDisplayEventModelByID(_eventViewModel.SelectedEvent.EventId);
            var selectedEvent = events.FirstOrDefault();
            if (selectedEvent != null)
            {
                _selectedEvent = selectedEvent;
                _eventId = _selectedEvent.EventId;
                EventName = _selectedEvent.EventName;
                EventDate = _selectedEvent.EventDate; // Загружаем дату
                RawEventDateInput = _selectedEvent.EventDate.ToString("dd.MM.yyyy"); // Преобразуем дату в строку для отображения
                SelectedEventTypeName = _selectedEvent.EventTypeName;
            }
        }

        private async void LoadContacts()
        {
            var contacts = await _contactService.GetAllContactsNotOnEvent(_selectedEvent.EventId);
            Contacts = new ObservableCollection<Contact>(contacts);
        }

        private async void LoadContactsOnEvent()
        {
            var contacts = await _contactService.GetAllContactsOnEvent(_selectedEvent.EventId);
            ContactsOnEvent = new ObservableCollection<Contact>(contacts);
        }

        private async void LoadEventTypes()
        {
            var eventTypes = await _eventService.GetEventTypesAsync();
            EventTypes = new ObservableCollection<EventType>(eventTypes);
        }
    }
}

