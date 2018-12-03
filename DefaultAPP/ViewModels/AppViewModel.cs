using SupportXFLite.Controllers;
using SupportXFLite.ViewModels;

namespace DefaultAPP.ViewModels
{
    public  class AppViewModel : XFLiteBaseViewModel
    {
        public AppViewModel()
        {
        }

        protected override ISupportProjectXF GetSupportProject()
        {
            return App.Manager;
        }
    }
}