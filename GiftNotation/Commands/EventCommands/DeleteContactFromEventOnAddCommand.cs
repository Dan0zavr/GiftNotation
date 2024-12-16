﻿using GiftNotation.Services;
using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.Commands.EventCommands
{
    public class DeleteContactFromEventOnAddCommand : ICommand
    {
        private readonly AddEventViewModel _viewModel;

        public DeleteContactFromEventOnAddCommand(AddEventViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            // Убедимся, что выбран контакт на событии
            return _viewModel.SelectedContactOnEvent != null;
        }

        public async void Execute(object? parameter)
        {
            await DeleteContactFromEventAsync();
        }

        private async Task DeleteContactFromEventAsync()
        {
            var contact = _viewModel.SelectedContactOnEvent;
            if (contact != null)
            {
                    // Обновляем списки
                _viewModel.ContactsOnEvent.Remove(contact);  // Удаление из списка контактов на событии
                _viewModel.Contacts.Add(contact); // Добавление обратно в общий список контактов
                
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}