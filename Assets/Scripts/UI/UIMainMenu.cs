using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    // 상태창 및 인벤토리 버튼
    [SerializeField] private Button statusButton;        // 상태창 열기 버튼
    [SerializeField] private Button inventoryButton;     // 인벤토리 열기 버튼

    // 캐릭터 정보 텍스트 UI
    [SerializeField] private Text idText;                // 캐릭터 ID 텍스트
    [SerializeField] private Text jobText;               // 캐릭터 직업 텍스트
    [SerializeField] private Text levelText;             // 캐릭터 레벨 텍스트
    [SerializeField] private Text goldText;              // 캐릭터 골드 텍스트
    [SerializeField] private Text expText;               // 캐릭터 경험치 텍스트
    // 경험치 게이지 이미지
    [SerializeField] private Image expFillImage;         // 경험치 게이지 이미지

    // 캐릭터 정보를 받아와 UI에 반영
    public void SetCharacterInfo(Character character)
    {
        idText.text = character.Id;
        jobText.text = character.Job;
        levelText.text = character.Level.ToString();
        goldText.text = character.Gold.ToString();
        expText.text = $"{character.CurrentExp} / {character.MaxExp}";

        float ratio = (character.MaxExp == 0) ? 0f : (float)character.CurrentExp / character.MaxExp;
        expFillImage.fillAmount = Mathf.Clamp01(ratio); // 경험치 비율에 따라 게이지 채우기
    }

    private void Start()
    {
        // 버튼 클릭 이벤트 등록
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    // 상태창 열기
    private void OpenStatus()
    {
        gameObject.SetActive(false);
        UIManager.Instance.StatusUI.gameObject.SetActive(true);
    }

    // 인벤토리 창 열기
    private void OpenInventory()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InventoryUI.gameObject.SetActive(true);
    }
}
