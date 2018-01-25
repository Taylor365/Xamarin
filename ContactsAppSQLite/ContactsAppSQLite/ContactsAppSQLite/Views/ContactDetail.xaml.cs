using ContactsAppSQLite.Models;
using ContactsAppSQLite.PCL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsAppSQLite.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetail : ContentPage
	{
        ObservableCollection<Contact> _contacts;
        Contact temp = new Contact();
        bool isNew = false;
        private SQLiteAsyncConnection _connection;

        public ContactDetail(ObservableCollection<Contact> _ds, SQLiteAsyncConnection conn)
        {
            _contacts = _ds;
            isNew = true;

            InitializeComponent();
            _connection = conn;
        }

        public ContactDetail(ObservableCollection<Contact> _ds, SQLiteAsyncConnection conn, int userId)
        {
            _contacts = _ds;

            temp = _contacts.Single(x => x.Id == userId);

            BindingContext = new Contact
            {
                Id = temp.Id,
                FirstName = temp._firstName,
                LastName = temp._lastName,
                Phone = temp.Phone,
                Email = temp.Email,
                Blocked = temp.Blocked
            };

            InitializeComponent();
            _connection = conn;
        }

        async void Handle_Submit(object sender, ClickedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(fName.Text) || String.IsNullOrWhiteSpace(lName.Text))
            {
                 await DisplayAlert("Warning","You must enter a Full Name","Close");
            }
            else
            {
                if (!isNew)
                {
                    temp = new Contact
                    {
                        Id = temp.Id,
                        Update = true,
                        FirstName = fName.Text,
                        LastName = lName.Text,
                        Phone = phone.Text,
                        Email = email.Text,
                        Blocked = isBlocked.IsToggled
                    };
                }
                else
                {
                    temp = new Contact
                    {
                        Update = true,
                        FirstName = fName.Text,
                        LastName = lName.Text,
                        Phone = phone.Text,
                        Email = email.Text,
                        Blocked = isBlocked.IsToggled
                    };
                }

                if (!_contacts.Any())
                {
                    await _connection.InsertAsync(temp);
                    _contacts.Add(temp);
                }
                else if (!isNew)
                {
                    foreach (Contact item in _contacts)
                    {
                        if (temp.Id == item.Id)
                        {
                            item.Update = true;
                            item.FirstName = temp.FirstName;
                            item.LastName = temp.LastName;
                            item.Phone = temp.Phone;
                            item.Email = temp.Email;
                            item.Blocked = temp.Blocked;
                            item.Update = false;
                            await _connection.UpdateAsync(temp);
                            break;
                        }
                    }
                }
                else
                {
                    await _connection.InsertAsync(temp);
                    _contacts.Add(temp);
                }

                await Navigation.PopAsync();
            }
        }
    }
}