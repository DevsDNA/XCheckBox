using System;
using System.ComponentModel;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XCheckBox.XCheckBox), typeof(XCheckBox.iOS.CheckBoxRenderer))]
namespace XCheckBox.iOS
{
    [Preserve(AllMembers = true)]
    public class CheckBoxRenderer : ViewRenderer
    {
        private double width = 20;
        private double height = 20;

        private XCheckBox element;
        private BemCheckBox.BemCheckBox control;

        public new static void Init()
        {
            var date = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            element = (XCheckBox)Element;
            control = new BemCheckBox.BemCheckBox(new CGRect(0, 0, width, height), new MyBemCheckBoxDelegate((checkedValue) =>
            {
                element.RaiseChecked(checkedValue);
            }));
            SetNativeControl(control);

            if (Control == null)
                return;
            
            if (Element.WidthRequest != -1)
            {
                width = Element.WidthRequest;
            }

            if(Element.HeightRequest != -1)
            {
                height = Element.HeightRequest;
            }
                                    
            ChangeCheckBoxColors();
            
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;

            if(e.PropertyName == XCheckBox.CheckBoxColorProperty.PropertyName)
            {
                ChangeCheckBoxColors();
            }

            if(e.PropertyName == XCheckBox.CheckBoxValueProperty.PropertyName)
            {
                control.On = element.CheckBoxValue;
            }
        }

        private void ChangeCheckBoxColors()
        {
            (Control as BemCheckBox.BemCheckBox).FillColor = element.CheckBoxColor.ToUIColor();
            (Control as BemCheckBox.BemCheckBox).TintColor = element.CheckBoxColor.ToUIColor();
        }
    }

    
}