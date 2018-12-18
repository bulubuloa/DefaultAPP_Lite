using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace DefaultAPP.ViewModels
{
    public class TestModel
    {
        public int Index;
    }

    public class LoginViewModel : AppViewModel
    {
        private List<TestModel> _TestItems;
        public List<TestModel> TestItems
        {
            get => _TestItems;
            set
            {
                _TestItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand => new Command(OnNextCommand);
        private async void OnNextCommand()
        {
            IsBusy = true;
            await NavigationToPage<MainViewModel>();
            IsBusy = false;
        }

        private string _Percent;
        public string Percent
        {
            get => _Percent;
            set
            {
                _Percent = value;
                OnPropertyChanged();
            }
        }

        private string _PercentValue;
        public string PercentValue
        {
            get => _PercentValue;
            set
            {
                _PercentValue = value;
                OnPropertyChanged();
            }
        }

        private string _ListPrice;
        public string ListPrice
        {
            get => _ListPrice;
            set
            {
                _ListPrice = value;
                OnPropertyChanged();
            }
        }

        private string _LastPrice;
        public string LastPrice
        {
            get => _LastPrice;
            set
            {
                _LastPrice = value;
                OnPropertyChanged();
            }
        }

        public ICommand PercentChangedCommand => new Command<TextChangedEventArgs>(OnPercentChangedCommand);
        private async void OnPercentChangedCommand(TextChangedEventArgs textChangedEventArgs)
        {
            try
            {

                var tempPercentValue = "";

                if(string.IsNullOrEmpty(textChangedEventArgs.NewTextValue))
                {
                    tempPercentValue = "";
                }
                else
                {
                    var listValue = Double.Parse(ListPrice);
                    var percent = Double.Parse(textChangedEventArgs.NewTextValue) * 0.01;

                    tempPercentValue = ((listValue * percent)) + "";
                }

                PercentValue = tempPercentValue;
                CalTotal();
            }
            catch (Exception ex)
            {

            }
        }

        public ICommand PercentValueChangedCommand => new Command<TextChangedEventArgs>(OnPercentValueChangedCommand);
        private async void OnPercentValueChangedCommand(TextChangedEventArgs textChangedEventArgs)
        {
            try
            {
               
                var tempPercent = "";

                if (string.IsNullOrEmpty(textChangedEventArgs.NewTextValue))
                {
                    tempPercent = "";
                }
                else
                {
                    var listValue = Double.Parse(ListPrice);
                    var percentValue = Double.Parse(textChangedEventArgs.NewTextValue);

                    tempPercent = ((percentValue*100) /listValue) + "";
                }
                Percent = tempPercent;
                CalTotal();
            }
            catch (Exception ex)
            {

            }
        }

        private void CalTotal()
        {
            try
            {
                var listValue = Double.Parse(ListPrice);

                if (string.IsNullOrEmpty(PercentValue))
                {
                    LastPrice = listValue + "";
                }
                else
                {
                    var percentValue = Double.Parse(PercentValue);
                    LastPrice = (listValue - percentValue) + "";
                }
            }
            catch (Exception ex)
            {

            }
        }

        public LoginViewModel()
        {
            ListPrice = "100000000";

            TestItems = new List<TestModel>()
            {
                new TestModel()
                {
                    Index = 0
                }
            };
        }
    }
}