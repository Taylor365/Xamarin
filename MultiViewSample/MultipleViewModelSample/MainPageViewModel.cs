using Prism.Mvvm;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultipleViewModelSample
{
  public class MainPageViewModel : BindableBase
  {
    public ViewModel1 VM1Instance { get; set; }
    public ViewModel2 VM2Instance { get; set; }
    public ViewModel3 VM3Instance { get; set; }

    public MainPageViewModel()
    {
      VM3Instance = new ViewModel3();
      VM2Instance = new ViewModel2(VM3Instance);
      VM1Instance = new ViewModel1(VM2Instance);
    }
  }
}
