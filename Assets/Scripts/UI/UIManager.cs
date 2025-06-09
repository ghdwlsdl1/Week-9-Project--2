using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus statusUI;
    [SerializeField] private UIInventory inventoryUI;

    public UIMainMenu MainMenu => mainMenu;
    public UIStatus StatusUI => statusUI;
    public UIInventory InventoryUI => inventoryUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
