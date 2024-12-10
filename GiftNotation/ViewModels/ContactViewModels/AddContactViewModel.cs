using GiftNotation.Services;
using GiftNotation.Models;
using GiftNotation.Commands.ContactCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class AddContactViewModel : ViewModelBase
    {
        private string _contactName;
        private DateTime _bday;

        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private RelpType _selectedRelpType;

        public ObservableCollection<Gifts> Gifts { get; private set; } = new ObservableCollection<Gifts>();
        public ObservableCollection<RelpType> RelpTypes { get; private set; } = new ObservableCollection<RelpType>();

        // Для хранения выбранных подарков
        public ObservableCollection<Gifts> SelectedGifts { get; private set; } = new ObservableCollection<Gifts>();

        public string ContactName
        {
            get => _contactName;
            set => SetProperty(ref _contactName, value);
        }

        public DateTime Bday
        {
            get => _bday;
            set => SetProperty(ref _bday, value);
        }

        public RelpType? SelectedRelpType
        {
            get => _selectedRelpType;
            set => SetProperty(ref _selectedRelpType, value);
        }

        public ICommand AddContactCommand { get; }

        public AddContactViewModel(ContactService contactService, GiftService giftService, ContactViewModel contactViewModel)
        {
            _contactService = contactService;
            _giftService = giftService;
            LoadGifts();
            LoadRelpTypes();
            AddContactCommand = new AddContactCommand(contactService, contactViewModel, this);
        }

        public async void LoadGifts()
        {
            var gifts = await _giftService.GetAllGifts();
            foreach (var gift in gifts)
            {
                Gifts.Add(gift);
            }
        }

        public async void LoadRelpTypes()
        {
            var relpTypes = await _contactService.GetAllRelpTypes();
            foreach (var relpType in relpTypes)
            {
                RelpTypes.Add(relpType);
            }
        }

        // Метод для обработки выбора подарков (опционально)
        public void ToggleGiftSelection(Gifts gift)
        {
            if (SelectedGifts.Contains(gift))
            {
                SelectedGifts.Remove(gift);
            }
            else
            {
                SelectedGifts.Add(gift);
            }
        }
    }

}
