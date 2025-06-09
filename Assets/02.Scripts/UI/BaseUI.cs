using UnityEngine;

namespace _02.Scripts.UI
{
    public enum UIType
    {
        None = 0,
        MainWindow,
        InventoryWindow,
        EquipWindow,
        StatWindow,
        ConfirmPopup,
        ToastMessage,
    }

    public abstract class BaseUI : MonoBehaviour
    {
        public abstract UIType UIType { get; }

        public virtual void OnOpen()
        {

        }

        public virtual void OnOpen(OpenParam param) => OnOpen();

        public virtual void OnClose()
        {
        }
    }
    
    public abstract class BaseWindow : BaseUI { }
    public abstract class BasePopup : BaseUI { }
    public abstract class BaseFixed : BaseUI { }

}