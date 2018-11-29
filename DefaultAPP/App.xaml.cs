using System;
using DefaultAPP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DefaultAPP
{
    public partial class App : Application
    {
        public static InitializeProject Manager;
        static App()
        {
            Manager = new InitializeProject();
        }


        public App()
        {
            InitializeComponent();

            var navigationService = Manager.NavigationManager;
            navigationService.NavigateToAsync<LoginViewModel>(true);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}