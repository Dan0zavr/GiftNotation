using GiftNotation.Commands.EventCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using System.Collections.ObjectModel;
using System.Globalization;


namespace GiftNotation.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly EventViewModel _eventViewModel;
        private readonly GiftService _giftService;
        private readonly IDateMediator _mediator;

        private int _eventId;
        private string _eventName;
        private DateTime _date;
        private EventType _eventType;
        private Contact _selectedContact;
        private AddContactOnEventOnAddCommand _addContactOnEventCommand;
        private Event _selectedEvent;

        private Gifts _selectedGift;

        public ObservableCollection<EventType> EventTypes { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> ContactsOnEvent { get; set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Gifts> Gifts { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<Gifts> RemovedGifts { get; set; } = new ObservableCollection<Gifts>(); // Коллекция для удалённых подарков
        public ObservableCollection<GiftContact> SelectedGifts { get; set; } = new ObservableCollection<GiftContact>();

        private Contact _selectedContactOnEvent;

        public Contact SelectedContactOnEvent
        {
            get => _selectedContactOnEvent;
            set
            {
                if (SetProperty(ref _selectedContactOnEvent, value))
                {
                    // Обновляем состояние кнопки удаления
                    DeleteContactFromEventCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _rawEventDateInput;  // Для привязки к TextBox
        private DateTime _eventDate;  // Для хранения выбранной или введенной даты
        private bool _isEventDateValid = true;

        // Валидация даты
        public bool IsEventDateValid
        {
            get => _isEventDateValid;
            set
            {
                if (_isEventDateValid != value)
                {
                    _isEventDateValid = value;
                    OnPropertyChanged(nameof(IsEventDateValid));
                }
            }
        }

        // Свойство для ввода/выбора даты
        public string RawEventDateInput
        {
            get => _rawEventDateInput;
            set
            {
                if (SetProperty(ref _rawEventDateInput, value))
                {
                    // Преобразование введенной строки в дату
                    TrySetEventDate(value);
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
                    // Обновляем строку ввода на основе выбранной даты
                    RawEventDateInput = value.ToString("dd.MM.yyyy");
                    IsEventDateValid = CheckDateOnEventTypeTruth(RawEventDateInput);
                    
                }
            }
        }


        private bool _isEventNameValid = true; // По умолчанию валидно
        public bool IsEventNameValid
        {
            get => _isEventNameValid;
            set
            {
                if (_isEventNameValid != value)
                {
                    _isEventNameValid = value;
                    OnPropertyChanged(nameof(IsEventNameValid));

                }
            }
        }


        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (SetProperty(ref _selectedContact, value))
                {
                    // Уведомляем команду, что условие для CanExecute могло измениться
                    AddContactOnEventCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string EventName
        {
            get => _eventName;
            set
            {
                if (_eventName != value)
                {
                    _eventName = value;
                    OnPropertyChanged(nameof(EventName));
                    IsEventNameValid = !string.IsNullOrWhiteSpace(_eventName); // Обновляем состояние валидации
                }
            }
        }

        public EventType EventType
        {
            get { return _eventType; }
            set
            {
                if(SetProperty(ref _eventType, value))
                {
                    IsEventDateValid = CheckDateOnEventTypeTruth(RawEventDateInput);
                }
            }
        }

        public DeleteContactFromEventOnAddCommand DeleteContactFromEventCommand { get; }
        public AddEventCommand AddEventCommand { get; }
        public AddContactOnEventOnAddCommand AddContactOnEventCommand => _addContactOnEventCommand; // Команда доступна в ViewModel

        public Gifts SelectedGift
        {
            get => _selectedGift;
            set
            {
                if (SetProperty(ref _selectedGift, value))
                {
                    // Когда подарок выбран, сразу удаляем его из коллекции
                    RemoveGiftFromCollection(value);
                }
            }
        }

        public AddEventViewModel(EventService eventService, EventViewModel eventViewModel, ContactService contactService, GiftService giftService, IDateMediator dateMediator)
        {
            _eventService = eventService;
            _contactService = contactService;
            _eventViewModel = eventViewModel;
            _giftService = giftService;
            _mediator = dateMediator;

            _mediator.DateChanged += OnDateChanged;

            AddEventCommand = new AddEventCommand(eventService, this, _eventViewModel, dateMediator);
            _addContactOnEventCommand = new AddContactOnEventOnAddCommand(this);
            DeleteContactFromEventCommand = new DeleteContactFromEventOnAddCommand(this);

            LoadContacts();
            LoadEventTypes();
            LoadGifts();

        }

        private void OnDateChanged(DateTime? newDate)
        {
            if (newDate.HasValue && newDate.Value != _date)
            {
                SetProperty(ref _date, newDate.Value);
            }
        }

        private bool TrySetEventDate(string value)
        {
            if (CheckDateOnEventTypeTruth(value))
            {
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    EventDate = parsedDate; // Устанавливаем дату, если она прошла все проверки
                    IsEventDateValid = true;
                    return true;
                }
            }

            IsEventDateValid = false; // Устанавливаем флаг валидности
            return false;
        }

        private async void LoadContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            Contacts = new ObservableCollection<Contact>(contacts);
        }

        private async void LoadEventTypes()
        {
            var eventTypes = await _eventService.GetEventTypesAsync();
            EventTypes = new ObservableCollection<EventType>(eventTypes);
        }

        public async void LoadGifts()
        {
            // Получаем список подарков из сервиса
            var gifts = await _giftService.GetGiftsNotForContact();

            if (gifts != null && gifts.Any())
            {
                Gifts = new ObservableCollection<Gifts>(gifts); // Обновляем через свойство, чтобы уведомить интерфейс
            }
        }

        private bool CheckDateOnEventTypeTruth(string value)
        {
            if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                // Проверяем на соответствие типу события
                if (EventType != null)
                {
                    if (EventType.EventTypeName == "Новый год" && !(parsedDate.Day == 31 && parsedDate.Month == 12))
                    {
                        return false;
                    }
                    if (EventType.EventTypeName == "Рождество" && !(parsedDate.Day == 25 && parsedDate.Month == 12))
                    {
                        return false;
                    }
                }

                return true; // Дата валидна
            }

            return false; // Дата невалидна
        }

        private void RemoveGiftFromCollection(Gifts gift)
        {
            if (gift != null)
            {
                // Удаляем выбранный подарок из коллекции Gifts
                Gifts.Remove(gift);
                // Добавляем подарок в коллекцию удалённых подарков
                RemovedGifts.Add(gift);
            }
        }
    }

}
