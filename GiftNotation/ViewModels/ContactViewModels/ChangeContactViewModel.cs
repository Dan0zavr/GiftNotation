using GiftNotation.Commands.ContactCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace GiftNotation.ViewModels
{
    public class ChangeContactViewModel : ViewModelBase
    {
        private readonly ContactViewModel _contactViewModel;
        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private readonly EventService _eventService;

        private int _contactId;
        private string _contactName;
        private DateTime _bday;
        private RelpType _selectedRelpType;
        private string _selectedRelpTypeName;
        private Gifts _selectedGift;
        private Gifts _selectedGiftForContact;

        private DisplayContactModel _selectedContact;
        private AddGiftForContactOnChangeCommand _addGiftForContactOnChangeCommand;

        public ObservableCollection<Gifts> Gifts { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<Gifts> GiftsForContact { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<RelpType> RelpTypes { get; private set; } = new ObservableCollection<RelpType>();

        // Для хранения выбранных подарков
        public ObservableCollection<Gifts> _selectedGifts = new ObservableCollection<Gifts>();

        public int ContactId
        {
            get => _contactId;
            set => SetProperty(ref _contactId, value);
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
                    _contactName = value;
                    OnPropertyChanged(nameof(ContactName));
                    IsContactNameValid = !string.IsNullOrWhiteSpace(_contactName);
                }
            }
        }

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
                    if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        Bday = parsedDate;
                        IsEventDateValid = true;
                    }
                    else
                    {
                        IsEventDateValid = false;
                    }
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

        public RelpType? SelectedRelpType
        {
            get => _selectedRelpType;
            set => SetProperty(ref _selectedRelpType, value);
        }

        public string SelectedRelpTypeName
        {
            get => _selectedRelpTypeName;
            set => SetProperty(ref _selectedRelpTypeName, value);
        }

        public Gifts SelectedGift
        {
            get => _selectedGift;
            set
            {
                if (SetProperty(ref _selectedGift, value))
                {
                    AddGiftForContactOnChangeCommand.RaiseCanExecuteChanged();
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

        public ChangeContactCommand ChangeContactCommand { get; }
        public AddGiftForContactOnChangeCommand AddGiftForContactOnChangeCommand => _addGiftForContactOnChangeCommand;

        public DeleteGiftForContactOnChangeCommand DeleteGiftForContactCommand { get; }

        public ChangeContactViewModel(ContactService contactService, GiftService giftService, ContactViewModel contactViewModel, EventService eventService)
        {
            _contactService = contactService;
            _giftService = giftService;
            _contactViewModel = contactViewModel;
            _eventService = eventService;
            LoadData();
            LoadGiftsForContact();
            LoadGifts();
            LoadRelpTypes();
            ChangeContactCommand = new ChangeContactCommand(contactService, contactViewModel, this, _eventService);
            _addGiftForContactOnChangeCommand = new AddGiftForContactOnChangeCommand(this);
            DeleteGiftForContactCommand = new DeleteGiftForContactOnChangeCommand(this);
        }

        public async void LoadData()
        {
            var contacts = await _contactService.GetContactDisplayModelByIdAsync(_contactViewModel.SelectedContact.ContactId);

            foreach (var contact in contacts)
            {
                _selectedContact = contact;
            }
            _contactId = _selectedContact.ContactId;
            _contactName = _selectedContact.ContactName;
            _bday = _selectedContact.Bday;
            _selectedRelpTypeName = _selectedContact.RelpTypeName;
        }

        public async void LoadGifts()
        {
            var gifts = await _giftService.GetAllGiftNotForContact(_selectedContact.ContactId);
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

        private async void LoadGiftsForContact()
        {
            var gifts = await _giftService.GetAllGiftsForContact(_selectedContact.ContactId);
            GiftsForContact = new ObservableCollection<Gifts>(gifts);
        }

    }
}

