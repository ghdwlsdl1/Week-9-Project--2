using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    // 메인 메뉴로 돌아가는 버튼
    [SerializeField] private Button backButton;

    // 캐릭터의 능력치를 표시하는 텍스트 UI들
    [SerializeField] private Text attackText;           // 공격력
    [SerializeField] private Text defenseText;          // 방어력
    [SerializeField] private Text hpText;               // 체력
    [SerializeField] private Text criticalText;         // 치명타

    private void Start()
    {
        // 뒤로가기 버튼 클릭 시 상태창 비활성화 → 메인 메뉴 활성화
        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            UIManager.Instance.MainMenu.gameObject.SetActive(true);
        });
    }

    // 캐릭터 정보를 받아와 텍스트 UI에 반영
    public void SetCharacterInfo(Character character)
    {
        attackText.text = character.Attack.ToString();
        defenseText.text = character.Defense.ToString();
        hpText.text = character.HP.ToString();
        criticalText.text = character.Critical.ToString();
    }
}
