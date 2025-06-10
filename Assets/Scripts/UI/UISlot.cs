using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private GameObject equipMark;     // 장착 여부를 표시하는 마크 오브젝트
    [SerializeField] private GameObject outline;       // 슬롯 강조 표시용 외곽선 오브젝트
    [SerializeField] private Button slotButton;        // 클릭 이벤트를 처리할 버튼 컴포넌트
    [SerializeField] private Image iconImage;          // 아이템 아이콘 이미지

    private ItemData itemData;                         // 슬롯에 표시된 아이템 데이터
    private Character character;                       // 이 슬롯이 속한 캐릭터 정보
    private bool isEquipped;                           // 장착 상태 여부

    // 슬롯에 아이템 데이터를 설정하고 UI 갱신
    public void SetItem(ItemData item, Character owner, bool equipped = false)
    {
        itemData = item;
        character = owner;
        isEquipped = equipped;

        iconImage.sprite = item.icon;
        iconImage.enabled = (item.icon != null);

        equipMark.SetActive(isEquipped);
        outline.SetActive(false);

        // 기존 리스너 제거 후 클릭 이벤트 등록
        slotButton.onClick.RemoveAllListeners();
        slotButton.onClick.AddListener(OnClickSlot);
    }

    // 슬롯을 비우고 초기 상태로 되돌림
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

    // 슬롯 클릭 시 장착 / 해제 처리
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

        // UI 갱신: 장착 마크 및 외곽선
        equipMark.SetActive(isEquipped);
        outline.SetActive(isEquipped);

        // 상태창과 인벤토리 UI 갱신
        UIManager.Instance.StatusUI.SetCharacterInfo(character);
        UIManager.Instance.InventoryUI.InitInventoryUI(character.Inventory, character);
    }
}
