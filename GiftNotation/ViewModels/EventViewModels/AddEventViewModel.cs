using GiftNotation.Commands.EventCommands;
using GiftNotation.Commands.GiftCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly EventViewModel _eventViewModel;
        private readonly GiftService _giftService;
        private readonly IDateMediator _mediator;

        private int _eventId;
        private string _eventName;
        private DateTime _date;
        private EventType _eventType;
        private Contact _selectedContact;
        private AddContactOnEventOnAddCommand _addContactOnEventCommand;

        private Gifts _selectedGift;

        public ObservableCollection<EventType> EventTypes { get; private set; } = new ObservableCollection<EventType>();
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> ContactsOnEvent { get; set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Gifts> Gifts { get; set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<Gifts> RemovedGifts { get; set; } = new ObservableCollection<Gifts>(); // Коллекция для удалённых подарков
        public ObservableCollection<GiftContact> SelectedGifts { get; set; } = new ObservableCollection<GiftContact>();

        private Contact _selectedContactOnEvent;

        public Contact SelectedContactOnEvent
        {
            get => _selectedContactOnEvent;
            set
            {
                if (SetProperty(ref _selectedContactOnEvent, value))
                {
                    // Обновляем состояние кнопки удаления
                    DeleteContactFromEventCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (SetProperty(ref _selectedContact, value))
                {
                    // Уведомляем команду, что условие для CanExecute могло измениться
                    AddContactOnEventCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string EventName
        {
            get => _eventName;
            set
            {
                if (SetProperty(ref _eventName, value))
                {
                    // Пример правильного вызова RaiseCanExecuteChanged для конкретной команды
                    AddEventCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DateTime EventDate
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }


        public EventType EventType
        {
            get { return _eventType; }
            set => SetProperty(ref _eventType, value);
        }

        public DeleteContactFromEventOnAddCommand DeleteContactFromEventCommand { get; }
        public AddEventCommand AddEventCommand { get; }
        public AddContactOnEventOnAddCommand AddContactOnEventCommand => _addContactOnEventCommand; // Команда доступна в ViewModel

        public Gifts SelectedGift
        {
            get => _selectedGift;
            set
            {
                if (SetProperty(ref _selectedGift, value))
                {
                    // Когда подарок выбран, сразу удаляем его из коллекции
                    RemoveGiftFromCollection(value);
                }
            }
        }

        public AddEventViewModel(EventService eventService, EventViewModel eventViewModel, ContactService contactService, GiftService giftService, IDateMediator dateMediator)
        {
            _eventService = eventService;
            _contactService = contactService;
            _eventViewModel = eventViewModel;
            _giftService = giftService;
            _mediator = dateMediator;

            _mediator.DateChanged += OnDateChanged;

            var eventDetails = _mediator.GetEventDetails();
            if (eventDetails != null)
            {
                EventName = eventDetails.EventName;
                EventDate = eventDetails.EventDate;
                EventType.EventTypeName = eventDetails.EventTypeName;
            }

            AddEventCommand = new AddEventCommand(eventService, this, _eventViewModel, dateMediator);
            _addContactOnEventCommand = new AddContactOnEventOnAddCommand(this);
            DeleteContactFromEventCommand = new DeleteContactFromEventOnAddCommand(this);

            LoadContacts();
            LoadEventTypes();
            LoadGifts();
            
        }

        private void OnDateChanged(DateTime? newDate)
        {
            if (newDate.HasValue)
            {
                _date = newDate.Value;  // Обновление локальной даты
                SetProperty(ref _date, _date);   // Обновление уведомления о изменении
            }
        }

        private async void LoadContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            Contacts = new ObservableCollection<Contact>(contacts);
        }

        private async void LoadEventTypes()
        {
            var eventTypes = await _eventService.GetEventTypesAsync();
            EventTypes = new ObservableCollection<EventType>(eventTypes);
        }

        public async void LoadGifts()
        {
            // Получаем список подарков из сервиса
            var gifts = await _giftService.GetGiftsNotForContact();

            if (gifts != null && gifts.Any())
            {
                Gifts = new ObservableCollection<Gifts>(gifts); // Обновляем через свойство, чтобы уведомить интерфейс
            }
        }

        private void RemoveGiftFromCollection(Gifts gift)
        {
            if (gift != null)
            {
                // Удаляем выбранный подарок из коллекции Gifts
                Gifts.Remove(gift);
                // Добавляем подарок в коллекцию удалённых подарков
                RemovedGifts.Add(gift);
            }
        }
    }

}
