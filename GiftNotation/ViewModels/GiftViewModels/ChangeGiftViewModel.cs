using GiftNotation.Models;
using GiftNotation.Services;
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


        private string _giftName;
        private string _giftDescription;
        private string _url;
        private double _price;
        private string _giftPic;
        private string _contactName;
        private string _eventName;

        private Status? _selectedStatus;
        private Contact? _selectedContact;
        private Event? _selectedEvent;

        public ObservableCollection<Status> Statuses { get; private set; } = new ObservableCollection<Status>();
        public ObservableCollection<Contact> Contacts { get; private set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Event> Events { get; private set; } = new ObservableCollection<Event>();

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

        public string ContactName
        {
            get => _contactName;
            set => SetProperty(ref _contactName, value);
        }

        public string EventNmae
        {
            get => _eventName;
            set => SetProperty(ref _eventName, value);
        }


        public Status? SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                SetProperty(ref _selectedStatus, value);

            }
        }

        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => SetProperty(ref _selectedContact, value);
        }

        public Event? SelectedEvent
        {
            get => _selectedEvent;
            set => SetProperty(ref _selectedEvent, value);
        }

        ICommand ChangeGiftCommand;

        public ChangeGiftViewModel(GiftViewModel giftViewModel, GiftService giftService)
        {
            _giftViewModel = giftViewModel;
            _giftService = giftService;
            LoadStatuses();
        }

        private async void LoadStatuses()
        {
            var statuses = await _giftService.GetAllStatuses();
            foreach (var status in statuses)
            {
                Statuses.Add(status);
            }
        }

        private async void LoadData()
        {

        }

    }
}
