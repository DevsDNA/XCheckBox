using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Widget;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XCheckBox.XCheckBox), typeof(XCheckBox.Droid.CheckBoxRenderer))]
namespace XCheckBox.Droid
{
    [Preserve(AllMembers = true)]
    public class CheckBoxRenderer : ViewRenderer
    {
        public static void Init()
        {
            var date = DateTime.Now;            
        }

        private XCheckBox element;

        public CheckBoxRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            var control = new Android.Widget.CheckBox(Context);
            SetNativeControl(control);

            if (Element == null)
                return;

            element = (XCheckBox)Element;
            element.ChildRemoved += ChildRemoved;            

            control.CheckedChange += CheckedChanged;
            ChangeCheckBoxColor();
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == XCheckBox.CheckBoxColorProperty.PropertyName)
            {
                ChangeCheckBoxColor();
            }
        }


        private void ChangeCheckBoxColor()
        {
            (Control as CheckBox).ButtonTintList = ColorStateList.ValueOf(element.CheckBoxColor.ToAndroid());
        }

        private void CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            element?.RaiseChecked(e.IsChecked);
        }

        private void ChildRemoved(object sender, ElementEventArgs e)
        {
            element.ChildRemoved -= ChildRemoved;            
            (Control as Android.Widget.CheckBox).CheckedChange -= CheckedChanged;
        }
    }
}