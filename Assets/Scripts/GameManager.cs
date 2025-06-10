using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("캐릭터 초기값")]
    [SerializeField] private string id = "홍진";
    [SerializeField] private string job = "전사";
    [SerializeField] private int level = 5;
    [SerializeField] private int gold = 1000;
    [SerializeField] private int attack = 20;
    [SerializeField] private int defense = 10;
    [SerializeField] private int hp = 150;
    [SerializeField] private int critical = 5;
    [SerializeField] private int currentExp = 20;

    [Header("초기 아이템")]
    [SerializeField] private List<ItemData> startingItems;

    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
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

        foreach (var item in startingItems)
            Player.AddItem(Instantiate(item));

        UIManager.Instance.MainMenu.SetCharacterInfo(Player);
        UIManager.Instance.StatusUI.SetCharacterInfo(Player);
        UIManager.Instance.InventoryUI.InitInventoryUI(Player.Inventory, Player);
    }
}
