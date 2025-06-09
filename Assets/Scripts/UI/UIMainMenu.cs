using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    [SerializeField] private Text idText;
    [SerializeField] private Text jobText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text goldText;
    [SerializeField] private Text expText;
    [SerializeField] private Image expFillImage;  // 경험치 바 이미지

    public void SetCharacterInfo(Character character)
    {
        idText.text = character.Id;
        jobText.text = character.Job;
        levelText.text = character.Level.ToString();
        goldText.text = character.Gold.ToString();
        expText.text = $"{character.CurrentExp} / {character.MaxExp}";

        float ratio = (character.MaxExp == 0) ? 0f : (float)character.CurrentExp / character.MaxExp;
        expFillImage.fillAmount = Mathf.Clamp01(ratio);
    }

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    private void OpenStatus()
    {
        gameObject.SetActive(false);
        UIManager.Instance.StatusUI.gameObject.SetActive(true);
    }

    private void OpenInventory()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InventoryUI.gameObject.SetActive(true);
    }
}
