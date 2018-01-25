using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsAppSQLite.Models
{
    public class Contact : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
        public bool Update { get; set; }
        public string _lastName { get; set; }
        public string _firstName { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                if (Update == true)
                {
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                    Update = false;
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                if (Update == true)
                {
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                    Update = false;
                }
            }
        }

        public string FullName => string.Format("{0} {1}", FirstName, LastName);

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string m)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(m));
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
