using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsApp.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }

        public bool Update { get; set; }


        public string firstName { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set {
                firstName = value;
                if (Update == true)
                {
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string lastName { get; set; }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                if (Update == true)
                {
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
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
