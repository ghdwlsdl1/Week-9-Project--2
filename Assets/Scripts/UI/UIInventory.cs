using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(BackToMain);
    }

    private void BackToMain()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
    }
}
