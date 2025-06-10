using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private readonly List<UISlot> slotList = new();

    public void InitInventoryUI(List<ItemData> items)
    {
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);

        slotList.Clear();

        int slotCount = Mathf.Max(items.Count, 9);

        for (int i = 0; i < slotCount; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            UISlot slot = go.GetComponent<UISlot>();

            if (i < items.Count)
            {
                slot.SetItem(items[i], false);
            }
            else
            {
                slot.Clear();
            }

            slotList.Add(slot);
        }
    }
}
