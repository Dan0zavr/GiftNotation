using GiftNotation.Commands.EventCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        private string _eventName;
        private DateTime _date;

        private readonly EventService _eventService;
        private readonly EventViewModel _eventViewModel;
        private EventType _eventType;

        public ObservableCollection<EventType> Events { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<Contact> Contacts { get; private set; } = new ObservableCollection<Contact>();

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
        public EventType EventType
        {
            get { return _eventType; }
            set => SetProperty(ref _eventType, value);
        }

        public ICommand AddEventCommand { get; }

        public AddEventViewModel(EventService eventService, EventViewModel eventViewModel) { 
            
            _eventService = eventService;
            _eventViewModel = eventViewModel;            
            AddEventCommand = new AddEventCommand(eventService, this, _eventViewModel);

        }
    }
}
