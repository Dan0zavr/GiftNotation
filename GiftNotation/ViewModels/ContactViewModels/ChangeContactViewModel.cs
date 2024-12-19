using GiftNotation.Commands.ContactCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ContactName
        {
            get => _contactName;
            set => SetProperty(ref _contactName, value);
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

