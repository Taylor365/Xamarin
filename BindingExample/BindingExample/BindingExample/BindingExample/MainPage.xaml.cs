using Xamarin.Forms;

namespace BindingExample
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      BindingContext = new MainViewModel();
    }
  }
}
