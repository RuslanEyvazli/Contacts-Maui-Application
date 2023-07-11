using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.MAUI.Models
{
    public class ContactRepository
    {
        private static List<Contact> _contacts = new List<Contact> {
            new Contact{ContactId=1, Name="Ruslan Eyvazli", Email="rus.eyvazli@outlook.com", Phone = "+48 516 492 663", Address = "Warsaw" },
            new Contact{ContactId=2, Name="Joy Pliph", Email="jy.pliph@outlook.com", Phone = "+47 000 000 000", Address="Oslo" },
            new Contact{ContactId=3, Name="Micheal Tobey", Email="mheal.tobeyy@outlook.com", Phone = "+48 000 000 000", Address="Krakow" }
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int contactId) 
        {
            var contact = _contacts.FirstOrDefault<Contact>(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact { ContactId = contact.ContactId, Name = contact.Name, Email = contact.Email, Phone = contact.Phone, Address = contact.Address };
            }
            return null;
        }
        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;
            var contactToUpdate = _contacts.FirstOrDefault<Contact>(x => x.ContactId == contactId);
            if (contactToUpdate == null) return;
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;

        }
    }
}
