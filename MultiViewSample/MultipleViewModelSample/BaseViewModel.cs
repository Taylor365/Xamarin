using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace MultipleViewModelSample
{
  public class BaseViewModel : BindableBase
  {
    public IPageDialogService _dialogService;
    public INavigationService _navigationService;

    public BaseViewModel()
    {

    }
  }
}
