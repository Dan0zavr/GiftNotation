using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftNotation.Models;
using GiftNotation.Services.UniversalService;

namespace GiftNotation.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task AddContact(Contact contact);
        Task<bool> DeleteContact(int id);
        Task<Contact> UpdateContact(int id);
    }
}
