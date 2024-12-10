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
    public class EventViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayEventModel> _events;
        private readonly EventService _eventService;

        public DisplayEventModel selectedEvent;


        public DisplayEventModel SelectedEvent 
        { 
            get => selectedEvent;
            set
            {
                SetProperty(ref selectedEvent, value);
                ((DeleteEventCommand)DeleteEventCommand).RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<DisplayEventModel> Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        public ICommand DeleteEventCommand { get; set; }

        public EventViewModel(EventService eventService)
        {
            _eventService = eventService;
            DeleteEventCommand = new DeleteEventCommand(this, _eventService);
            LoadEvents();
        }

        public async void LoadEvents()
        {
            // Здесь вы можете подключиться к базе данных через сервис или репозиторий
            var events = await _eventService.GetEventsAsync(); // Это пример, ваш метод получения данных
            Events = new ObservableCollection<DisplayEventModel>(events);
        }
    }
}
