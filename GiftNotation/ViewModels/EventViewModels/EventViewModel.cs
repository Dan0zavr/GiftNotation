﻿using GiftNotation.Commands;
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
using System;
using System.Windows.Input;
using System.ComponentModel;

namespace GiftNotation.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayEventModel> _events;
        private readonly EventService _eventService;
        private readonly FiltersViewModel _filtersViewModel;

        public DisplayEventModel selectedEvent;


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

        public EventViewModel(EventService eventService, FiltersViewModel filtersViewModel)
        {
            _eventService = eventService;
            _filtersViewModel = filtersViewModel;
            DeleteEventCommand = new DeleteEventCommand(this, _eventService);
            OpenAddEventCommand = new OpenAddEventCommand(eventService, this);
            OpenChangeEventCommand = new OpenChangeEventCommand(this, _eventService);
            OpenCloseFilterCommand = new OpenCloseFilterCommand(_filtersViewModel);
            LoadEvents();
        }

        public async void LoadEvents()
        {
            // Здесь вы можете подключиться к базе данных через сервис или репозиторий
            var events = await _eventService.GetEventsAsync(); // Это пример, ваш метод получения данных
            Events = new ObservableCollection<DisplayEventModel>(events);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
