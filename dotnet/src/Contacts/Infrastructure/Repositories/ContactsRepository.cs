using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Contacts.Infrastructure.Models;

namespace Contacts.Infrastructure.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly DynamoDBContext _context;

        public ContactsRepository()
        {
            var config = new AmazonDynamoDBConfig();
            if (Environment.GetEnvironmentVariable("IS_LOCAL") == "TRUE")
            {
                config.ServiceURL = "http://localhost:8000";
            }
            
            var client = new AmazonDynamoDBClient(config);
            _context = new DynamoDBContext(client, new DynamoDBContextConfig
            {
                TableNamePrefix = Environment.GetEnvironmentVariable("TABLENAME_PREFIX")
            });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var scan = _context.ScanAsync<Contact>(new List<ScanCondition>());
            var contacts = new List<Contact>();
            while (!scan.IsDone)
            {
                contacts.AddRange(await scan.GetNextSetAsync());
            }
            return contacts;
        }

        public Task<Contact> GetById(string id)
        {
            return _context.LoadAsync<Contact>(id);
        }

        public async Task<Contact> CreateNew(Contact contact)
        {
            contact.Id = contact.Id ?? Guid.NewGuid().ToString();
            contact.CreatedAt = DateTime.UtcNow;
            await _context.SaveAsync(contact);
            return contact;
        }

        public async Task<Contact> Update(string id, Contact contact)
        {
            await _context.SaveAsync(contact);
            return contact;
        }

        public Task Destroy(string id)
        {
            return _context.DeleteAsync<Contact>(id);
        }
    }
}