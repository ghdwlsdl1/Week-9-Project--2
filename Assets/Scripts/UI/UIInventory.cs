using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Transform slotParent;
    [SerializeField] private ScrollRect scrollRect;

    private readonly List<UISlot> slotList = new();

    private void Start()
    {
        backButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
    }

    public void InitInventoryUI(List<ItemData> items, Character character)
    {
        if (slotList.Count == 0)
        {
            slotList.AddRange(slotParent.GetComponentsInChildren<UISlot>(true));
            Debug.Log($"[InventoryUI] 슬롯 개수 로드됨: {slotList.Count}");
        }

        int activeSlotCount = Mathf.Max(items.Count, 9);

        for (int i = 0; i < slotList.Count; i++)
        {
            if (i < activeSlotCount)
            {
                if (i < items.Count)
                {
                    bool equipped = character.IsEquipped(items[i]);
                    slotList[i].SetItem(items[i], character, equipped);
                }
                else
                {
                    slotList[i].Clear();
                }

                slotList[i].gameObject.SetActive(true);
            }
            else
            {
                slotList[i].Clear();
                slotList[i].gameObject.SetActive(false);
            }
        }
        scrollRect.verticalNormalizedPosition = 1f;
    }
}
