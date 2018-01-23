using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ContactsApp.Models
{
    public class DetailsService
    {
        int counter = 100;

        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>
        {
            new Contact{ Id = 1, FirstName = "Jenny", LastName = "Dalby", Phone = "08762522", Email = "Jen@gmail.com", Blocked = false},
            new Contact{ Id = 2, FirstName = "Jonny", LastName = "Paige", Phone = "08647547", Email = "Jonn@gmail.com", Blocked = false},
            new Contact{ Id = 3, FirstName = "Margaret", LastName = "Fulcan", Phone = "01757362", Email = "mfu@gmail.com", Blocked = false}

        };

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact newContact)
        {
            foreach (Contact item in _contacts)
            {
                if (item.Id == newContact.Id)
                {
                    item.Update = true;
                    item.FirstName = newContact.FirstName;
                    item.LastName = newContact.LastName;
                    item.Phone = newContact.Phone;
                    item.Email = newContact.Email;
                    item.Blocked = newContact.Blocked;
                    item.Update = false;
                    break;
                }
            }
        }

        public Contact GetContactDetails(int contactId)
        {
            return _contacts.SingleOrDefault(c => c.Id == contactId);
        }

        public int GetNewId()
        {
            counter++;
            int newId = counter;
            return newId;
        }
    }
}
