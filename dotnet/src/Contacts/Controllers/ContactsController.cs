using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Infrastructure;
using Contacts.Infrastructure.Models;
using Contacts.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Contact>> Get()
        {
            return _contactsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Task<Contact> Get(string id)
        {
            return _contactsRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _contactsRepository.CreateNew(contact);
            return CreatedAtAction("Get", contact, new {id = res.Id});
        }

        [HttpPut("{id}")]
        public Task<Contact> Put(string id, [FromBody] Contact contact)
        {
            return _contactsRepository.Update(id, contact);
        }

        [HttpDelete("{id}")]
        public Task Delete(string id)
        {
            return _contactsRepository.Destroy(id);
        }
    }
}