using _02.Scripts.Player;
using _09.ScriptableObjects.Script;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class InventorySlotUI : MonoBehaviour
    {
        public Button slotButton;
        public Image iconImage;
        public Image equippedImage;
        public TextMeshProUGUI quantityText;

        private InventoryWindow parentWindow; // 부모 윈도우의 참조
        private int slotIndex;               // 자신의 슬롯 인덱스

        public void Initialize(InventoryWindow window, int index)
        {
            parentWindow = window;
            slotIndex = index;
        
            // 버튼 클릭 시 OnSlotClicked 메소드가 호출되도록 리스너 추가
            slotButton.onClick.AddListener(OnSlotClicked);
        }
        
         public void UpdateSlot(InventorySlot slotData)
         {
             if (slotData != null && slotData.itemData != null)
             {
                 // 아이템이 슬롯에 존재할 경우
                 iconImage.sprite = slotData.itemData.itemIcon;
                 iconImage.gameObject.SetActive(true); // 아이콘을 보이게 함

                 // 아이템이 여러 개일 경우에만 수량 텍스트 표시
                 if (slotData.quantity > 1)
                 {
                     quantityText.text = slotData.quantity.ToString();
                     quantityText.gameObject.SetActive(true);
                 }
                 else
                 {
                     quantityText.gameObject.SetActive(false);
                 }
                //장착 여부 표시
                 if (slotData.isEquipped)    
                 {
                     equippedImage.gameObject.SetActive(true);
                 }
                 else
                 {
                     equippedImage.gameObject.SetActive(false);
                 }
             }
             else
             {
                 // 슬롯이 비어있을 경우
                 ClearSlot();
             }
         }
         
         public void ClearSlot()
         {
             iconImage.gameObject.SetActive(false);
             quantityText.gameObject.SetActive(false);
             iconImage.gameObject.SetActive(false);
             equippedImage.gameObject.SetActive(false);
         }

         public void OnSlotClicked()
         {
             // 부모 윈도우에게 자신의 인덱스를 알리며 클릭 이벤트를 전달
             parentWindow.OnSlotClicked(slotIndex);
         }
         private void OnDestroy()
         {
             slotButton.onClick.RemoveAllListeners();
         }
    }
}
