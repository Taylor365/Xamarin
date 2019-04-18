using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CustomControls.ViewModel
{
  public class ExampleViewmodel :INotifyPropertyChanged
  {
    string statusMessage = "";
    public string StatusMessage
    {
      get { return statusMessage; }
      set
      {
        if (statusMessage != value)
        {
          statusMessage = value;
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusMessage"));
        }
      }
    }

    public Command MyCommand { get; private set; }

    public ExampleViewmodel()
    {
      try
      {
        MyCommand = new Command(() =>
        {
          StatusMessage = "You have activated the command!";
        });
      }
      catch (Exception ex)
      {
        
      }

    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
