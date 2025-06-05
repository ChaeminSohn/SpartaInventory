using UnityEngine;

namespace _02.Scripts.UI
{
    public enum UIType
    {
        None = 0,
        FixedUI,    //항상 켜져 있는 고정된 UI
        WindowUI,   //창 형태로 단일 표시되는 UI
        PopupUI,    //확인, 취소 등 단일 목적의 팝업창
    }
    public abstract class BaseUI: MonoBehaviour
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
}