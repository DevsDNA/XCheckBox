using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XCheckBox
{
    public class XCheckBox : View
    {        
        public static BindableProperty CommandCheckedProperty =
            BindableProperty.Create(
                nameof(CommandChecked),
                typeof(ICommand),
                typeof(XCheckBox),
                null);

        public static BindableProperty CheckBoxColorProperty =
            BindableProperty.Create(
                nameof(CheckBoxColor),
                typeof(Color),
                typeof(XCheckBox),
                Color.FromRgb(47, 123, 255));

        public static BindableProperty CheckBoxValueProperty =
            BindableProperty.Create(
                nameof(CheckBoxValue),
                typeof(bool),
                typeof(XCheckBox),
                false,
                BindingMode.TwoWay);                                        

        public ICommand CommandChecked
        {
            get => (ICommand)GetValue(CommandCheckedProperty);
            set => SetValue(CommandCheckedProperty, value);
        }

        public Color CheckBoxColor
        {
            get => (Color)GetValue(CheckBoxColorProperty);
            set => SetValue(CheckBoxColorProperty, value);
        }

        public bool CheckBoxValue
        {
            get => (bool)GetValue(CheckBoxValueProperty);
            set => SetValue(CheckBoxValueProperty, value);
        }

        public event EventHandler<bool> EventHandlerCheckedValue;

        public void RaiseChecked(bool value)
        {
            CheckBoxValue = value;
            CommandChecked?.Execute(value);
            EventHandlerCheckedValue?.Invoke(this, value);            
        }
    }
}
