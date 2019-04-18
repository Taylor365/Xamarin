using Prism.Mvvm;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultipleViewModelSample
{
    public class ViewModel3 : BindableBase
  {
    public string LabelText { get; set; } = "ViewModel 3";
    public ObservableCollection<object> ListOfTaskObjects { get; set; }
    public ICommand OnPageTappedCommand { get; private set; }

    private bool _isVM3Visible = false;
    public bool IsVM3Visible
    {
      get { return _isVM3Visible; }
      set
      {
        if (_isVM3Visible != value)
        {
          _isVM3Visible = value;
          RaisePropertyChanged();
        }
      }
    }

    public ViewModel3()
    {
      int x = 2;
      string y = "three";
      bool z = true;

      ListOfTaskObjects = new ObservableCollection<object> {x, y, z};
      OnPageTappedCommand = new Command(async vm => await OnPageTappedCommandExecuted());
    }

    private async Task OnPageTappedCommandExecuted()
    {     
      await Application.Current.MainPage.DisplayActionSheet("Alert", "You have been alerted", "OK");
    }
  }
}
