using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Infrastructure.Models;

namespace Contacts.Infrastructure.Repositories
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetById(string id);
        Task<Contact> CreateNew(Contact contact);
        Task<Contact> Update(string id, Contact contact);
        Task Destroy(string id);
    }
}