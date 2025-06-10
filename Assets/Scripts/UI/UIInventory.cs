using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    // 뒤로가기 버튼
    [SerializeField] private Button backButton;

    // 인벤토리 칸
    [SerializeField] private Transform slotParent;

    // 스크롤 초기화를 위한 ScrollRect 참조
    [SerializeField] private ScrollRect scrollRect;

    // 실제 슬롯 객체들 저장 리스트
    private readonly List<UISlot> slotList = new();

    private void Start()
    {
        // 뒤로가기 버튼 클릭 시 메인 메뉴로 이동
        backButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        // 인벤토리 비활성화 후 메인 메뉴 활성화
        gameObject.SetActive(false);
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
    }

    // 인벤토리 UI를 초기화하고 슬롯에 아이템 배치
    public void InitInventoryUI(List<ItemData> items, Character character)
    {
        // 처음 한 번만 슬롯 목록 수집
        if (slotList.Count == 0)
        {
            slotList.AddRange(slotParent.GetComponentsInChildren<UISlot>(true));
            Debug.Log($"[InventoryUI] 슬롯 개수 로드됨: {slotList.Count}");
        }

        // 최소 9칸은 항상 표시되도록 보장
        int activeSlotCount = Mathf.Max(items.Count, 9);

        for (int i = 0; i < slotList.Count; i++)
        {
            if (i < activeSlotCount)
            {
                if (i < items.Count)
                {
                    // 장착 여부에 따라 아이템 표시
                    bool equipped = character.IsEquipped(items[i]);
                    slotList[i].SetItem(items[i], character, equipped);
                }
                else
                {
                    // 비어 있는 슬롯은 초기화만
                    slotList[i].Clear();
                }

                slotList[i].gameObject.SetActive(true);
            }
            else
            {
                // 사용하지 않는 슬롯은 비활성화
                slotList[i].Clear();
                slotList[i].gameObject.SetActive(false);
            }
        }

        // 스크롤을 항상 맨 위로 초기화
        scrollRect.verticalNormalizedPosition = 1f;
    }
}

