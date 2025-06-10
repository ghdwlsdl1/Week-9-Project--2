using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private GameObject equipMark;
    [SerializeField] private GameObject outline;
    [SerializeField] private Button slotButton;

    private ItemData itemData;
    private bool isEquipped;

    public void SetItem(ItemData item, bool equipped = false)
    {
        itemData = item;
        isEquipped = equipped;

        equipMark.SetActive(isEquipped);
        outline.SetActive(isEquipped);

        slotButton.onClick.RemoveAllListeners();
        slotButton.onClick.AddListener(OnClickSlot);
    }

    public void Clear()
    {
        itemData = null;
        isEquipped = false;

        equipMark.SetActive(false);
        outline.SetActive(false);

        slotButton.onClick.RemoveAllListeners();
    }

    private void OnClickSlot()
    {
        if (itemData == null) return;

        isEquipped = !isEquipped;
        equipMark.SetActive(isEquipped);
        outline.SetActive(isEquipped);
    }
}
