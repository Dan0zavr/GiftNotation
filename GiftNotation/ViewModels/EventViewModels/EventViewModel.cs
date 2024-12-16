using GiftNotation.Commands;
using GiftNotation.Commands.EventCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Views;
using GiftNotation.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GiftNotation.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    public class EventViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayEventModel> _events;
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly FiltersViewModel _filtersViewModel;
        private readonly FilterWindowService _filterWindowService;

        public DisplayEventModel selectedEvent;
        private Window? _filtersWindow;

        private bool _isFiltersWindowVisible;

        public bool IsFiltersWindowVisible
        {
            get => _isFiltersWindowVisible;
            set => SetProperty(ref _isFiltersWindowVisible, value);
        }

        public DisplayEventModel SelectedEvent
        {
            get => selectedEvent;
            set
            {
                SetProperty(ref selectedEvent, value);
                ((DeleteEventCommand)DeleteEventCommand).RaiseCanExecuteChanged();
                ((OpenChangeEventCommand)OpenChangeEventCommand).RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<DisplayEventModel> Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        public ICommand DeleteEventCommand { get; set; }
        public ICommand OpenAddEventCommand { get; set; }
        public ICommand OpenChangeEventCommand { get; set; }
        public ICommand OpenCloseFilterCommand { get; set; }

        public EventViewModel(EventService eventService, FiltersViewModel filtersViewModel, ContactService contactService, FilterWindowService filterWindowService)
        {
            _eventService = eventService;
            _contactService = contactService;
            _filtersViewModel = filtersViewModel;
            _filterWindowService = filterWindowService;
            DeleteEventCommand = new DeleteEventCommand(this, _eventService);
            OpenAddEventCommand = new OpenAddEventCommand(eventService, this, _contactService);
            OpenChangeEventCommand = new OpenChangeEventCommand(this, _eventService, _contactService);
            OpenCloseFilterCommand = new OpenCloseFilterCommand(_filterWindowService);

            LoadEvents();
        }

        public async void LoadEvents()
        {
            var events = await _eventService.GetEventsAsync();
            Events = new ObservableCollection<DisplayEventModel>(events);
        }
    }

}
