using System;
using DefaultAPP.ViewModels;
using Xamarin.Forms;

namespace DefaultAPP.Views.Templates
{
    public class TestTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Tem1 { set; get; }
        public DataTemplate Tem2 { set; get; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is TestModel model)
            {
                if(model.Index == 0)
                {
                    return Tem1;
                }
                else
                {
                    return Tem2;
                }
            }
            throw new NotImplementedException();
        }
    }
}