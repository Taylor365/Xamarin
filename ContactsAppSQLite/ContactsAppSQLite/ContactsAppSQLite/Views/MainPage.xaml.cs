using ContactsAppSQLite.Models;
using ContactsAppSQLite.PCL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsAppSQLite.Views
{
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();
         
            //_connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MySQLite.db4"));
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(contacts);

            listView.ItemsSource = _contacts;

            base.OnAppearing();
        }

        async void Handle_Selection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            await Navigation.PushAsync(new ContactDetail(_contacts, _connection, contact.Id));

        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ContactDetail(_contacts, _connection));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            var response = await DisplayAlert("Confirm", "Are you sure you want to delete " + _contacts[0] + "?", "Confirm", "Cancel");

            if (response)
            {
                await _connection.DeleteAsync(contact);
                _contacts.Remove(contact);
            }
        }
    }
}
