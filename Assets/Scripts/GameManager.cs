using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character Player { get; private set; }

    [Header("초기 아이템")]
    [SerializeField] private List<ItemData> startingItems;

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
        SetData();
    }

    public void SetData()
    {
        Player = new Character(
            id: "홍진",
            job: "전사",
            level: 5,
            gold: 1000,
            attack: 20,
            defense: 10,
            hp: 150,
            critical: 5,
            currentExp: 20
        );

        foreach (var item in startingItems)
            Player.AddItem(Object.Instantiate(item)); // 개별 인스턴스로 복사

        UIManager.Instance.MainMenu.SetCharacterInfo(Player);
        UIManager.Instance.StatusUI.SetCharacterInfo(Player);
        UIManager.Instance.InventoryUI.InitInventoryUI(Player.Inventory);
    }
}
