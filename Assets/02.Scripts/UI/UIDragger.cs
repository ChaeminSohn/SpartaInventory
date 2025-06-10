using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _02.Scripts.UI
{
    public class UIDragger : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        // 이동시킬 대상 (창 본체)의 RectTransform
        [SerializeField]
        private RectTransform targetRectTransform;

        private Canvas canvas;  //부모 캔버스

        // 마우스 클릭 시작 지점과 UI 위치의 차이를 저장할 변수
        private Vector2 offset;

        private void Start()
        {
            canvas = GetComponentInParent<Canvas>();
        }

        // 스크립트가 붙은 UI 요소를 처음 클릭했을 때 1회 호출
        public void OnPointerDown(PointerEventData eventData)
        {
            // targetRectTransform이 설정되지 않았다면 부모의 RectTransform을 사용
            if (targetRectTransform == null)
            {
                targetRectTransform = (RectTransform)transform.parent;
            }

            // 창의 현재 위치와 마우스 포인터의 위치 사이의 간격을 계산하여 저장
            offset = (Vector2)targetRectTransform.position - eventData.position;
        }

        // 마우스를 드래그하는 동안 계속 호출
        public void OnDrag(PointerEventData eventData)
        {
            if (targetRectTransform == null || canvas == null) return;

            // 현재 마우스 위치에 아까 계산한 간격을 더해줘서 창의 새 위치를 결정
            targetRectTransform.position = eventData.position + offset;
            
            //화면 밖으로 나가지 않도록 위치 보정
            KeepWindowInBounds();
        }
        
        private void KeepWindowInBounds()
        {
            // 캔버스의 RectTransform을 기준으로 경계 계산
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            // 창의 현재 위치 
            Vector2 anchoredPos = targetRectTransform.anchoredPosition;

            // 창의 크기의 절반
            float halfWidth = targetRectTransform.rect.width / 2;
            float halfHeight = targetRectTransform.rect.height / 2;

            // 캔버스의 경계
            float minX = -canvasRect.rect.width / 2 + halfWidth;
            float maxX = canvasRect.rect.width / 2 - halfWidth;
            float minY = -canvasRect.rect.height / 2 + halfHeight;
            float maxY = canvasRect.rect.height / 2 - halfHeight;
            
            //주의!) 캔버스의 Pivot, Anchor 설정이 기본(중앙)이 아니라면 제대로 작동하지 않을 수 있음
            
            // 위치를 경계 안으로 제한
            anchoredPos.x = Mathf.Clamp(anchoredPos.x, minX, maxX);
            anchoredPos.y = Mathf.Clamp(anchoredPos.y, minY, maxY);

            // 보정된 위치를 다시 적용
            targetRectTransform.anchoredPosition = anchoredPos;
        }

    }
}