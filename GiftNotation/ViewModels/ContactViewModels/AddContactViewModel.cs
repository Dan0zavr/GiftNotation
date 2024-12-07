using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels
{
    public class AddContactViewModel : ViewModelBase
    {
        private readonly ContactViewModel _viewModel;
        private readonly ContactService _contactService;

        public AddContactViewModel(ContactViewModel viewModel, ContactService contactService)
        {
            _viewModel = viewModel;
            _contactService = contactService;
        }
    }
}
