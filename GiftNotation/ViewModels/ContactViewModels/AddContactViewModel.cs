using GiftNotation.Commands.ContactCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.ObjectModel;
using System.Globalization;

namespace GiftNotation.ViewModels
{
    public class AddContactViewModel : ViewModelBase
    {
        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private readonly EventService _eventService;

        private string _contactName;
        private DateTime _bday;
        private RelpType _selectedRelpType;
        private Gifts _selectedGift;
        private Gifts _selectedGiftForContact;
        private AddGiftForContactOnAddCommand _addGiftForContactOnAddCommand;

        public ObservableCollection<Gifts> Gifts { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<Gifts> GiftsForContact { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<RelpType> RelpTypes { get; private set; } = new ObservableCollection<RelpType>();

        // Для хранения выбранных подарков
        public ObservableCollection<Gifts> _selectedGifts = new ObservableCollection<Gifts>();

        private string _rawEventDateInput;  // Для привязки к TextBox
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

        public DateTime Bday
        {
            get => _bday;
            set
            {
                if (SetProperty(ref _bday, value))
                {
                    // Обновляем строку ввода на основе выбранной даты
                    RawEventDateInput = value.ToString("dd.MM.yyyy");
                    IsEventDateValid = true;
                }
            }
        }

        private bool _isContactNameValid = true; // По умолчанию валидно
        public bool IsContactNameValid
        {
            get => _isContactNameValid;
            set
            {
                if (_isContactNameValid != value)
                {
                    _isContactNameValid = value;
                    OnPropertyChanged(nameof(IsContactNameValid));

                }
            }
        }

        public string ContactName
        {
            get => _contactName;
            set
            {
                if (SetProperty(ref _contactName, value))
                {
                    IsContactNameValid = !string.IsNullOrWhiteSpace(value); // Переместите проверку сюда
                    OnPropertyChanged(nameof(ContactName)); // Не нужно дважды вызывать OnPropertyChanged для одного свойства
                }
            }
        }

        public RelpType? SelectedRelpType
        {
            get => _selectedRelpType;
            set => SetProperty(ref _selectedRelpType, value);
        }

        public Gifts SelectedGift
        {
            get => _selectedGift;
            set
            {
                if (SetProperty(ref _selectedGift, value))
                {
                    AddGiftForContactOnAddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public Gifts SelectedGiftForContact
        {
            get => _selectedGiftForContact;
            set
            {
                if (SetProperty(ref _selectedGiftForContact, value))
                {
                    // Уведомляем команду, что условие для выполнения изменилось
                    DeleteGiftForContactCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public AddContactCommand AddContactCommand { get; }
        public AddGiftForContactOnAddCommand AddGiftForContactOnAddCommand => _addGiftForContactOnAddCommand;

        public DeleteGiftForContactOnAddCommand DeleteGiftForContactCommand { get; }

        public AddContactViewModel(ContactService contactService, GiftService giftService, ContactViewModel contactViewModel, EventService eventService)
        {
            _contactService = contactService;
            _giftService = giftService;
            _eventService = eventService;

            LoadGifts();
            LoadRelpTypes();
            AddContactCommand = new AddContactCommand(contactService, contactViewModel, this, _eventService);
            _addGiftForContactOnAddCommand = new AddGiftForContactOnAddCommand(this);
            DeleteGiftForContactCommand = new DeleteGiftForContactOnAddCommand(this);

        }

        private bool TrySetEventDate(string value)
        {
            
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    Bday = parsedDate; // Устанавливаем дату, если она прошла все проверки
                    IsEventDateValid = true;
                    return true;
                }
            

            IsEventDateValid = false; // Устанавливаем флаг валидности
            return false;
        }


        public async void LoadGifts()
        {
            var gifts = await _giftService.GetAllGifts();
            Gifts = new ObservableCollection<Gifts>(gifts);
        }

        public async void LoadRelpTypes()
        {
            var relpTypes = await _contactService.GetAllRelpTypes();
            foreach (var relpType in relpTypes)
            {
                RelpTypes.Add(relpType);
            }
        }
    }

}
