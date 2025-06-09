using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

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
