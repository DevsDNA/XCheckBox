using System;

namespace XCheckBox.iOS
{
    public class MyBemCheckBoxDelegate : BemCheckBox.BemCheckBoxDelegate
    {
        private Action<bool> actionCheckBox;

        public MyBemCheckBoxDelegate(Action<bool> actionDelegate)
        {
            actionCheckBox = actionDelegate;
        }

        public override void DidTapCheckBox(bool checkBoxIsOn)
        {
            actionCheckBox?.Invoke(checkBoxIsOn);
        }
    }
}