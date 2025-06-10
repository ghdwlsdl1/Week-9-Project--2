using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private GameObject equipMark;
    [SerializeField] private Button slotButton;

    private Item itemData;

    public void SetItem(Item item, bool isEquipped)
    {
        itemData = item;
        equipMark.SetActive(isEquipped);

        slotButton.onClick.RemoveAllListeners();
        slotButton.onClick.AddListener(OnClickSlot);
    }

    public void Clear()
    {
        itemData = null;
        equipMark.SetActive(false);
        slotButton.onClick.RemoveAllListeners();
    }

    private void OnClickSlot()
    {
        if (itemData == null) return;

        itemData.isEquipped = !itemData.isEquipped;
        equipMark.SetActive(itemData.isEquipped);
    }
}
