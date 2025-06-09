using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private Text attackText;
    [SerializeField] private Text defenseText;
    [SerializeField] private Text hpText;
    [SerializeField] private Text criticalText;

    public void SetCharacterInfo(Character character)
    {
        attackText.text = character.Attack.ToString();
        defenseText.text = character.Defense.ToString();
        hpText.text = character.HP.ToString();
        criticalText.text = character.Critical.ToString();
    }
    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            UIManager.Instance.MainMenu.gameObject.SetActive(true);
        });
    }
}
