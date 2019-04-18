using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultipleViewModelSample
{
  public class ViewModel2 : BindableBase
  {
    public ViewModel3 _vm3Instance;
    public string LabelText { get; set; } = "ViewModel 2";

    private bool _isVM2Visible = false;
    public bool IsVM2Visible
    {
      get { return _isVM2Visible; }
      set
      {
        if (_isVM2Visible != value)
        {
          _isVM2Visible = value;
          RaisePropertyChanged();
        }
      }
    }
    public ICommand OnPageShowTappedCommand { get; private set; }
    public ICommand OnPageHideTappedCommand { get; private set; }

    public ViewModel2(ViewModel3 model3Instance)
    {
      _vm3Instance = model3Instance;
      OnPageShowTappedCommand = new Command(vm => OnPageShowTappedCommandExecuted());
      OnPageHideTappedCommand = new Command(vm => OnPageHideTappedCommandExecuted());
    }

    private void OnPageShowTappedCommandExecuted()
    {
      _vm3Instance.IsVM3Visible = true;
    }

    private void OnPageHideTappedCommandExecuted()
    {
      _vm3Instance.IsVM3Visible = false;
    }
  }
}
