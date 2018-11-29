using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DefaultAPP.ViewModels
{
    public class LoginViewModel : AppViewModel
    {
        public ICommand NextCommand => new Command(OnNextCommand);
        private async void OnNextCommand()
        {
            IsBusy = true;
            await NavigationToPage<MainViewModel>();
            IsBusy = false;
        }

        public LoginViewModel()
        {
        }
    }
}