using System;
using System.Threading.Tasks;
using DefaultAPP.ViewModels;
using DefaultAPP.Views;
using SupportXFLite.Controllers;
using SupportXFLite.Controllers.DJPools;
using SupportXFLite.Controllers.Navigations;
using SupportXFLite.ProjectArchitect.AESProjects.API;
using Xamarin.Forms;

namespace DefaultAPP
{
    public class InitializeProject : SupportProjectXF<BaseLocator, BaseNavigationService>
    {
        public InitializeProject()
        {
        }

        private async Task<NavigationPage> InitilizeNavigationPageWithPage(Xamarin.Forms.Page page)
        {
            var navigationPageWidget = new NavigationPage()
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#005e93")
            };
            if (page != null)
                await navigationPageWidget.PushAsync(page);
            return navigationPageWidget;
        }

        public override async Task SetupNavigationMap(Page page, Type viewModelType, object parameter, bool animate)
        {
            if (page is LoginView)
            {
                if (CurrentApplication.MainPage is NavigationPage)
                {
                    var currentNavigation = CurrentApplication.MainPage as NavigationPage;
                    await currentNavigation.PopToRootAsync(true);
                }
                else
                {
                    CurrentApplication.MainPage = await InitilizeNavigationPageWithPage(page);
                }
            }
            else if (CurrentApplication.MainPage is NavigationPage)
            {
                var currentNavigationX = (NavigationPage)CurrentApplication.MainPage;
                var currentPage = currentNavigationX.CurrentPage;

                if (page.GetType() != currentNavigationX.CurrentPage.GetType())
                    await currentNavigationX.PushAsync(page, true);
            }
            else
            {
                CurrentApplication.MainPage = await InitilizeNavigationPageWithPage(page);
            }
        }

        protected override void MappingViewAndViewModel(BaseNavigationService navigationManager)
        {
            navigationManager.Map<LoginViewModel,LoginView>();
            navigationManager.Map<MainViewModel,MainView>();
        }

        protected override void RegisterController(BaseLocator locator)
        {
            locator.Register<IAESAPIService, AESAPIService>();
        }

        protected override void RegisterViewModel(BaseLocator locator)
        {
            locator.Register<LoginViewModel>();
            locator.Register<MainViewModel>();
        }
    }
}