using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Commands.GiftCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class ChangeGiftViewModel : ViewModelBase
    {
        private readonly GiftViewModel _giftViewModel;
        private readonly GiftService _giftService;
        private readonly ContactService _contactService;
        private readonly EventService _eventService;

        private DisplayGiftModel _selectedGift;
        private int _giftId;
        private string _giftName;
        private string _giftDescription;
        private string _url;
        private double _price;
        private string _giftPic;

        private Contact? _selectedContact;
        private Event? _selectedEvent;
        private Status? _selectedStatus;

        private string? _selectedContactName;
        private string? _selectedEventName;
        private string? _selectedStatusName;

        public ObservableCollection<Status> Statuses { get; private set; } = new ObservableCollection<Status>();
        public ObservableCollection<Contact> Contacts { get; private set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Event> Events { get; private set; } = new ObservableCollection<Event>();

        public int GiftId => _giftId;

        public string GiftName
        {
            get => _giftName;
            set => SetProperty(ref _giftName, value);
        }

        public string Description
        {
            get => _giftDescription;
            set => SetProperty(ref _giftDescription, value);
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public string GiftPic
        {
            get => _giftPic;
            set => SetProperty(ref _giftPic, value);
        }

        public Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                SetProperty(ref _selectedContact, value);
                // Обновляем имя контакта при изменении выбора
                SelectedContactName = _selectedContact?.ContactName;
            }
        }

        public string? SelectedContactName
        {
            get => _selectedContactName;
            set => SetProperty(ref _selectedContactName, value);
        }

        public Event? SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                SetProperty(ref _selectedEvent, value);
                // Обновляем имя события при изменении выбора
                SelectedEventName = _selectedEvent?.EventName;
            }
        }

        public string? SelectedEventName
        {
            get => _selectedEventName;
            set => SetProperty(ref _selectedEventName, value);
        }

        public Status? SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                SetProperty(ref _selectedStatus, value);
                // Обновляем имя статуса при изменении выбора
                SelectedStatusName = _selectedStatus?.StatusName;
            }
        }

        public string? SelectedStatusName
        {
            get => _selectedStatusName;
            set => SetProperty(ref _selectedStatusName, value);
        }

        public ICommand ChangeGiftCommand { get; }

        public ChangeGiftViewModel(GiftViewModel giftViewModel, GiftService giftService, ContactService contactService, EventService eventService)
        {
            _giftViewModel = giftViewModel;
            _giftService = giftService;
            _eventService = eventService;
            _contactService = contactService;
            
            LoadContacts();
            LoadEvents();
            LoadStatuses();

            LoadData();
            ChangeGiftCommand = new ChangeGiftCommand(giftService, giftViewModel, this);
        }

        private async void LoadStatuses()
        {
            var statuses = await _giftService.GetAllStatuses();
            foreach (var status in statuses)
            {
                Statuses.Add(status);
            }
        }

        private async void LoadContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }
        private async void LoadEvents()
        {
            var events = await _eventService.GetAllEvents();
            foreach (var event_ in events)
            {
                Events.Add(event_);
            }
        }

        private async void LoadData()
        {
            var gifts = await _giftService.GetDisplayGiftModelByID(_giftViewModel.SelectedGift.GiftId);
            foreach (var gift in gifts)
            {
                _selectedGift = gift;
            }

            if (_selectedGift != null)
            {
                _giftId = _selectedGift.GiftId;
                GiftName = _selectedGift.GiftName;
                Description = _selectedGift.Description;
                Url = _selectedGift.Url;
                Price = _selectedGift.Price;
                GiftPic = _selectedGift.GiftPic;

                // Устанавливаем выбранные объекты по ID
                SelectedContact = Contacts.FirstOrDefault(c => c.ContactId == _selectedGift.ContactId);
                SelectedEvent = Events.FirstOrDefault(e => e.EventId == _selectedGift.EventId);
                SelectedStatus = Statuses.FirstOrDefault(s => s.StatusName ==  _selectedGift.StatusName);
            }
        }

    }
}
