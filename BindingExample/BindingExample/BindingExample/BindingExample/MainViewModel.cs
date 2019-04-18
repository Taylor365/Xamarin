using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindingExample
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Model> _listOfModels { get; set; }
    public ObservableCollection<Model> ListOfModels
    {
      get { return _listOfModels; }
      set
      {
        if (_listOfModels != value)
        {
          _listOfModels = value;
        }
      }
    }

    private Model _selectedModel;
    public Model SelectedModel
    {
      get { return _selectedModel; }
      set
      {
        _selectedModel = value;
        OnPropertyChanged("SelectedModel");
      }
    }

    private bool _isPickerSelected = false;
    public bool IsPickerSelected
    {
      get { return _isPickerSelected; }
      set
      {
        _isPickerSelected = value;
        OnPropertyChanged("IsPickerSelected");
      }
    }

    private bool _isListSelected = false;
    public bool IsListSelected
    {
      get { return _isListSelected; }
      set
      {
        _isListSelected = value;
        OnPropertyChanged("IsListSelected");
      }
    }

    public ICommand OnPickerSelectedCommand { get; }
    public ICommand OnListSelectedCommand { get; }

    public MainViewModel()
    {
      OnPickerSelectedCommand = new Command(OnPickerSelectedCommandExecuted);
      OnListSelectedCommand = new Command(OnListSelectedCommandExecuted);

      ListOfModels = new ObservableCollection<Model>();

      ListOfModels.Add(new Model
      {
        Name = "Picker",
        Numbers = new List<Number>(){
          new Number {Name = "One", Value = 1 },
          new Number {Name = "Two", Value = 2 },
          new Number {Name = "Three", Value = 3 },},
        Enabled = true
      });
      ListOfModels.Add(new Model
      {
        Name = "List",
        Numbers = new List<Number>(){
          new Number {Name = "One", Value = 1 },
          new Number {Name = "Two", Value = 2 },
          new Number {Name = "Three", Value = 3 },},
        Enabled = false
      });
    }

    private void OnPickerSelectedCommandExecuted()
    {
      SelectedModel = ListOfModels.Where(e => e.Name == "Picker").First();
      IsPickerSelected = true;
      IsListSelected = false;
    }

    private void OnListSelectedCommandExecuted()
    {
      SelectedModel = ListOfModels.Where(e => e.Name == "List").First();
      IsPickerSelected = false;
      IsListSelected = true;
    }
  }

  public class Model
  {
    public string Name { get; set; }
    public List<Number> Numbers { get; set; }
    public bool Enabled { get; set; }
  }

  public class Number
  {
    public string Name { get; set; }
    public int Value { get; set; }
  }
}
