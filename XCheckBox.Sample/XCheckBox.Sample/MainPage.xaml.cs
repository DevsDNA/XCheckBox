using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XCheckBox.Sample
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = this;            
		}
        
        private bool checkBoxValue;
        
        public bool CheckBoxValue
        {
            get => checkBoxValue;
            set
            {
                checkBoxValue = value;
                OnPropertyChanged(nameof(CheckBoxValue));
            }
        }

        public ICommand CheckBoxForAnotherPlaceCommand => new Command(PerformCheckBoxForAnotherPlace);

        private void PerformCheckBoxForAnotherPlace()
        {
            CheckBoxValue = !CheckBoxValue;
        }

    }
}
