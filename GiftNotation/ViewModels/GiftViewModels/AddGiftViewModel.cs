using GiftNotation.Commands.GiftCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.ViewModels.GiftViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class AddGiftViewModel : ViewModelBase, IAddOrEditGiftViewModel
    {
        private readonly GiftService _giftService;
        private readonly EventService _eventService;
        private readonly ContactService _contactService;

        private string _giftName;
        private string _giftDescription;
        private string _url;
        private double _price;
        private string _giftPic;

        private Status? _selectedStatus;
        private Contact? _selectedContact;
        private Event? _selectedEvent;

        public bool HasContacts => Contacts?.Count > 0;
        public bool HasEvents => Events?.Count > 0;

        public ObservableCollection<Status> Statuses { get; private set; } = new ObservableCollection<Status>();
        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            private set
            {
                if (_contacts != value)
                {
                    if (_contacts != null)
                    {
                        _contacts.CollectionChanged -= Contacts_CollectionChanged;
                    }

                    _contacts = value;

                    if (_contacts != null)
                    {
                        _contacts.CollectionChanged += Contacts_CollectionChanged;
                    }

                    OnPropertyChanged(nameof(Contacts));
                    OnPropertyChanged(nameof(HasContacts));
                }
            }
        }

        private void Contacts_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasContacts));
        }

        public ObservableCollection<Event> _events  = new ObservableCollection<Event>();

        public ObservableCollection<Event> Events
        {
            get => _events;
            private set
            {
                if (_events != value)
                {
                    if (_events != null)
                    {
                        _contacts.CollectionChanged -= Events_CollectionChanged;
                    }

                    _events = value;

                    if (_events != null)
                    {
                        _events.CollectionChanged += Events_CollectionChanged;
                    }

                    OnPropertyChanged(nameof(Events));
                    OnPropertyChanged(nameof(HasEvents));
                }
            }
        }
        private void Events_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasEvents));
        }

        private bool _isGiftNameValid = true; // По умолчанию валидно
        public bool IsGiftNameValid
        {
            get => _isGiftNameValid;
            set
            {
                if (_isGiftNameValid != value)
                {
                    _isGiftNameValid = value;
                    OnPropertyChanged(nameof(IsGiftNameValid));


                }
            }
        }


        public string GiftName
        {
            get => _giftName;
            set
            {
                if (_giftName != value)
                {
                    _giftName = value;
                    OnPropertyChanged(nameof(_giftName));
                    IsGiftNameValid = !string.IsNullOrWhiteSpace(_giftName); // Обновляем доступность команды
                }
            }
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

        public Status? SelectedStatus
        {
            get => _selectedStatus;
            set => SetProperty(ref _selectedStatus, value);

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


        public AddGiftCommand AddGiftCommand { get; }
        public ICommand OpenFileDialogForPicture { get; }

        public AddGiftViewModel(GiftService giftService, GiftViewModel giftViewModel, ContactService contactService, EventService eventService)
        {
            _giftService = giftService;
            _contactService = contactService;
            _eventService = eventService;

            AddGiftCommand = new AddGiftCommand(giftService, this, giftViewModel);
            OpenFileDialogForPicture = new OpenFileDialogForPictureCommand(this);
            LoadContacts();
            LoadEvents();
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
    }


}
