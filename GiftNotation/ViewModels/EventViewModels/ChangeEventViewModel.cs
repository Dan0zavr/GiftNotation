using GiftNotation.Commands.EventCommands;
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
    public class ChangeEventViewModel : ViewModelBase
    {
        private int _eventId;
        private string _eventName;
        private DateTime _date;
        private string _eventType;

        private readonly EventService _eventService;
        private readonly EventViewModel _eventViewModel;
        private DisplayEventModel _selectedEvent;
        private EventType _selectedEventType;

        public ObservableCollection<Contact?> _selectedContact;
        public ObservableCollection<EventType> Events { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<Contact> Contacts { get; private set; } = new ObservableCollection<Contact>();

        public int EventId
        {
            get { return _eventId; }
        }

        public string EventName
        {
            get { return _eventName; }
            set => SetProperty(ref _eventName, value);
        }
        public DateTime EventDate
        {
            get { return _date; }
            set
            {
                SetProperty(ref _date, value);
            }
        }

        public ObservableCollection<Contact?> ContactOnEvent
        {
            get { return _selectedContact; }
            set => SetProperty(ref _selectedContact, value);
        }
        public EventType? SelectedEventType
        {
            get { return _selectedEventType; }
            set => SetProperty(ref _selectedEventType, value);
        }

        public ICommand ChangeEventCommand { get; }

        public ChangeEventViewModel(EventService eventService, EventViewModel eventViewModel)
        {

            _eventService = eventService;
            _eventViewModel = eventViewModel;
            ChangeEventCommand = new ChangeEventCommand(eventService, this, _eventViewModel);
            LoadData();
        }

        private async void LoadData()
        {
            var events = await _eventService.GetDisplayEventModelByID(_eventViewModel.SelectedEvent.EventId);
            foreach (var event_ in events)
            {
                _selectedEvent = event_;
            }
            _eventId = _selectedEvent.EventId;
            _eventName = _selectedEvent.EventName;
            _date = _selectedEvent.EventDate;
            _eventType = _selectedEvent.EventTypeName;

        }
    }
}

