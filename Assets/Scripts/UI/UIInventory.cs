using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<UISlot> slotList = new List<UISlot>();

    private void Start()
    {
        backButton.onClick.AddListener(BackToMain);
    }

    private void BackToMain()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
    }

    public void InitInventoryUI(List<Item> items)
    {
        UISlot[] existingSlots = slotParent.GetComponentsInChildren<UISlot>();

        for (int i = 0; i < existingSlots.Length; i++)
        {
            if (i < items.Count)
            {
                existingSlots[i].SetItem(items[i], items[i].isEquipped);
            }
            else
            {
                existingSlots[i].Clear();
            }
        }

        for (int i = existingSlots.Length; i < items.Count; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            UISlot slot = go.GetComponent<UISlot>();
            slot.SetItem(items[i], items[i].isEquipped);
        }
    }
}
