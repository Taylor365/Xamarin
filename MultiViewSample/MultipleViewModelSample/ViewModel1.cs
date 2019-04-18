using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultipleViewModelSample
{
  public class ViewModel1 : BindableBase
  {
    public ViewModel2 _vm2Instance;
    public string LabelText { get; set; } = "ViewModel 1";
    public ICommand OnPageShowTappedCommand { get; private set; }
    public ICommand OnPageHideTappedCommand { get; private set; }

    public ViewModel1(ViewModel2 model2Instance)
    {
      OnPageShowTappedCommand = new Command(vm => OnPageShowTappedCommandExecuted());
      OnPageHideTappedCommand = new Command(vm => OnPageHideTappedCommandExecuted());
      _vm2Instance = model2Instance;
    }

    private void OnPageShowTappedCommandExecuted()
    {
      _vm2Instance.IsVM2Visible = true;
    }

    private void OnPageHideTappedCommandExecuted()
    {
      _vm2Instance.IsVM2Visible = false;
    }
  }
}
