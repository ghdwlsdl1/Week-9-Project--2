using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스 (전역 접근용)
    public static GameManager Instance { get; private set; }

    [Header("캐릭터 초기값")]
    [SerializeField] private string id = "홍진";              // 캐릭터 ID
    [SerializeField] private string job = "전사";             // 직업명
    [SerializeField] private int level = 5;                   // 시작 레벨
    [SerializeField] private int gold = 1000;                 // 시작 골드
    [SerializeField] private int attack = 20;                 // 기본 공격력
    [SerializeField] private int defense = 10;                // 기본 방어력
    [SerializeField] private int hp = 150;                    // 기본 체력
    [SerializeField] private int critical = 5;                // 기본 치명타 확률
    [SerializeField] private int currentExp = 20;             // 시작 경험치

    [Header("초기 아이템")]
    [SerializeField] private List<ItemData> startingItems;    // 시작 시 지급할 아이템 목록

    // 현재 게임의 플레이어 캐릭터
    public Character Player { get; private set; }

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }
    }

    private void Start()
    {
        // 캐릭터 생성 및 초기화
        Player = new Character(
            id,
            job,
            level,
            gold,
            attack,
            defense,
            hp,
            critical,
            currentExp
        );

        // 시작 아이템 지급
        foreach (var item in startingItems)
            Player.AddItem(Instantiate(item));

        // 초기 UI 정보 반영
        UIManager.Instance.MainMenu.SetCharacterInfo(Player);
        UIManager.Instance.StatusUI.SetCharacterInfo(Player);
        UIManager.Instance.InventoryUI.InitInventoryUI(Player.Inventory, Player);
    }
}
