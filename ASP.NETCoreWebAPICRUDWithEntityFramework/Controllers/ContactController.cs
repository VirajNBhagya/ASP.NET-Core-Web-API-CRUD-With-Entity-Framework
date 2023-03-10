using ASP.NETCoreWebAPICRUD.Data;
using ASP.NETCoreWebAPICRUD.Models;
using ASP.NETCoreWebAPICRUD.Models.ContactViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace ASP.NETCoreWebAPICRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly AddAPIDbContext db;

        public ContactController(AddAPIDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            return Ok(await db.Contacts.ToListAsync());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCon([FromRoute] int id)
        {
            var contact = await db.Contacts.FindAsync(id);
            if(contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address
            };
            await db.Contacts.AddAsync(contact);
            await db.SaveChangesAsync();

            return Ok(contact);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, UpdateContactRequest updateContactRequest)
        {
            var contact =await db.Contacts.FindAsync(id);
            if(contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Email = updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;

                await db.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var contact = await db.Contacts.FindAsync(id);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                await db.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
