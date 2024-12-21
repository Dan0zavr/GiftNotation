﻿using GiftNotation.Commands.ContactCommands;
using GiftNotation.Models;
using GiftNotation.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayContactModel> _сontacts;
        private ContactService _contactService;
        private GiftService _giftService;
        private readonly EventService _eventService;

        public DisplayContactModel selectedContact;

        public DisplayContactModel SelectedContact
        {
            get => selectedContact;
            set
            {
                SetProperty(ref selectedContact, value);
                ((DeleteContactCommand)DeleteContactCommand).RaiseCanExecuteChanged();
                ((OpenChangeContactCommand)OpenChangeContactCommand).RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<DisplayContactModel> Contacts
        {
            get { return _сontacts; }
            set { SetProperty(ref _сontacts, value); }
        }

        public ICommand OpenAddContactCommand { get; set; }
        public ICommand DeleteContactCommand { get; set; }
        public ICommand OpenChangeContactCommand { get; set; }

        public ContactViewModel(ContactService contactService, GiftService giftService, EventService eventService)
        {
            _contactService = contactService;
            _giftService = giftService;
            _eventService = eventService;
            OpenAddContactCommand = new OpenAddContactCommand(this, _contactService, _giftService, _eventService);
            DeleteContactCommand = new DeleteContactCommand(this, _contactService, _eventService);
            OpenChangeContactCommand = new OpenChangeContactCommand(this, _contactService, _giftService, _eventService);

            // Загрузка данных из базы данных или другого источника
            LoadContacts();

            //OpenChangeContactCommand = new OpenChangeGiftCommand(this, _contactService);
        }

        public async void LoadContacts()
        {
            // Здесь вы можете подключиться к базе данных через сервис или репозиторий
            var contacts = await _contactService.GetAllContactsAsync(); // Это пример, ваш метод получения данных
            Contacts = new ObservableCollection<DisplayContactModel>(contacts);
        }
    }
}
