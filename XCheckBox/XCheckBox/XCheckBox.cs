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

        public event EventHandler<bool> EventHandlerCheckedValue;

        public void RaiseChecked(bool value)
        {
            CommandChecked?.Execute(value);
            EventHandlerCheckedValue?.Invoke(this, value);            
        }

        protected override void OnChildRemoved(Element child)
        {
            base.OnChildRemoved(child);


        }
    }
}
