using System;
using SupportXFLite.Controllers.Navigations;
using SupportXFLite.ViewModels;

namespace DefaultAPP.ViewModels
{
    public abstract class AppViewModel : BaseViewModel
    {
        public AppViewModel()
        {
        }

        public override IStandardNavigationService IF_GetNavigationService()
        {
            return App.Manager.NavigationManager;
        }
    }
}