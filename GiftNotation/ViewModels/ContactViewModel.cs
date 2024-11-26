using GiftNotation.Models;
using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private ObservableCollection<ContactDisplayModel> _contacts;
        private ContactService _contactService;

        public ObservableCollection<ContactDisplayModel> Contact
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        public ContactViewModel(ContactService contactService) {
            _contactService = contactService;

            LoadContacts();
        }

        private async void LoadContacts()
        {
            var contacts = await _contactService.GetDisplayContactsAsync();
            Contact = new ObservableCollection<ContactDisplayModel>(contacts);
        }

        
    }
}
