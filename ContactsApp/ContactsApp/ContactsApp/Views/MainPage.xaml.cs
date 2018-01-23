using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ContactsApp
{
    public partial class MainPage : ContentPage
    {
        public DetailsService _service = new DetailsService();

        public MainPage()
        {
            _service = new DetailsService();

            InitializeComponent();

            listView.ItemsSource = _service.GetAllContacts();
        }

        async void Handle_Selection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            await Navigation.PushAsync(new ContactDetail(contact.Id, _service));

        }

        void Handle_Activate(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContactDetail(_service.GetNewId(), _service));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            var response = await DisplayAlert("Confirm", "Are you sure you want to delete " + _service.GetContactDetails(contact.Id).FullName + "?", "Confirm", "Cancel");

            if (response)
            {
                _service.RemoveContact(contact);
            }
        }
    }
}
