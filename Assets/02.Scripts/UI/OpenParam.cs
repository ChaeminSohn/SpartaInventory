using System;

namespace _02.Scripts.UI
{
    public abstract class OpenParam
    {

    }

    public class ConfirmPopupParam : OpenParam
    {
        public string Title;
        public string Message;
        public bool ShowCancel;
        public Action OnConfirm;
        public Action OnCancel;
    }
}


