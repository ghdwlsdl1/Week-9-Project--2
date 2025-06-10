using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private GameObject equipMark;
    [SerializeField] private GameObject outline;
    [SerializeField] private Button slotButton;
    [SerializeField] private Image iconImage;

    private ItemData itemData;
    private Character character;
    private bool isEquipped;

    public void SetItem(ItemData item, Character owner, bool equipped = false)
    {
        itemData = item;
        character = owner;
        isEquipped = equipped;

        iconImage.sprite = item.icon;
        iconImage.enabled = (item.icon != null);

        equipMark.SetActive(isEquipped);
        outline.SetActive(false);

        slotButton.onClick.RemoveAllListeners();
        slotButton.onClick.AddListener(OnClickSlot);
    }


    public void Clear()
    {
        itemData = null;
        character = null;
        isEquipped = false;

        iconImage.sprite = null;
        iconImage.enabled = false;

        equipMark.SetActive(false);
        outline.SetActive(false);
        slotButton.onClick.RemoveAllListeners();
    }

    private void OnClickSlot()
    {
        if (itemData == null || character == null)
            return;

        if (isEquipped)
        {
            character.UnEquip(itemData);
            isEquipped = false;
        }
        else
        {
            character.Equip(itemData);
            isEquipped = true;
        }

        equipMark.SetActive(isEquipped);
        outline.SetActive(isEquipped);

        UIManager.Instance.StatusUI.SetCharacterInfo(character);
        UIManager.Instance.InventoryUI.InitInventoryUI(character.Inventory, character);
    }
}
