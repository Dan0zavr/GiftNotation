﻿using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Commands.EventCommands
{
    public class AddContactOnEventOnChangeCommand
    {
        private readonly ChangeEventViewModel _viewModel;

        public AddContactOnEventOnChangeCommand(ChangeEventViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedContact != null;
        }

        public void Execute(object? parameter)
        {
            AddContactToEvent();
        }

        private void AddContactToEvent()
        {
            var contact = _viewModel.SelectedContact;
            if (contact != null)
            {
                _viewModel.ContactsOnEvent.Add(contact);
                _viewModel.Contacts.Remove(contact); // Удаление из общего списка
                _viewModel.SelectedContact = null;  // Сброс выбора контакта
            }
        }

        // Уведомляем привязку, что состояние команды могло измениться
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
