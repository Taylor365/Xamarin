using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetail : ContentPage
	{
        int intialId = 0;
        DetailsService _contacts = new DetailsService();
        Contact temp = new Contact();

        public ContactDetail(int userId, DetailsService _ds)
        {
            _contacts = _ds;

            if (userId <= _contacts.GetAllContacts().Last().Id)
            {
                temp = _contacts.GetContactDetails(userId);
                BindingContext = new Contact
                {
                    Id = temp.Id,
                    FirstName = temp.firstName,
                    LastName = temp.lastName,
                    Phone = temp.Phone,
                    Email = temp.Email,
                    Blocked = temp.Blocked
                };
            }
            intialId = userId;

            InitializeComponent();
        }

        void Handle_Submit(object sender, ClickedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(fName.Text) || String.IsNullOrWhiteSpace(lName.Text))
            {
                DisplayAlert("Warning","You must enter a Full Name","Close");
            }
            else
            {
                temp = new Contact
                {
                    Id = intialId,
                    FirstName = fName.Text,
                    LastName = lName.Text,
                    Phone = phone.Text,
                    Email = email.Text,
                    Blocked = isBlocked.IsToggled
                };

                if (intialId > _contacts.GetAllContacts().Last().Id)
                {
                    _contacts.AddContact(temp);
                }
                else
                    _contacts.UpdateContact(temp);

                Navigation.PopAsync();
            }
        }
    }
}