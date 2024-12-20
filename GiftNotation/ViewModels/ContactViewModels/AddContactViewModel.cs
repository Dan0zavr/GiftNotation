using GiftNotation.Commands.ContactCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System.Collections.ObjectModel;

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
                    if (_contactName != value)
                    {
                        _contactName = value;
                        OnPropertyChanged(nameof(ContactName));
                        IsContactNameValid = !string.IsNullOrWhiteSpace(_contactName); // Обновляем состояние валидации
                    }
                }
            }
        }


        public DateTime Bday
        {
            get => _bday;
            set => SetProperty(ref _bday, value);
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

            Bday = DateTime.Now;

            LoadGifts();
            LoadRelpTypes();
            AddContactCommand = new AddContactCommand(contactService, contactViewModel, this, _eventService);
            _addGiftForContactOnAddCommand = new AddGiftForContactOnAddCommand(this);
            DeleteGiftForContactCommand = new DeleteGiftForContactOnAddCommand(this);

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
