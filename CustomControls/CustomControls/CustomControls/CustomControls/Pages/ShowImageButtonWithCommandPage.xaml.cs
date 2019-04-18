using CustomControls.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControls
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ShowImageButtonWithCommandPage : ContentPage
  {
    public ShowImageButtonWithCommandPage()
    {
      BindingContext = new ExampleViewmodel();

      InitializeComponent();
    }
  }
}