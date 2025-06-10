using System.Collections.Generic;

public class Character
{
    // 기본 정보
    public string Id { get; private set; }           // 캐릭터 ID
    public string Job { get; private set; }          // 직업명
    public int Level { get; private set; }           // 현재 레벨
    public int Gold { get; private set; }            // 보유 골드

    // 전투 능력치
    public int Attack { get; private set; }          // 공격력
    public int Defense { get; private set; }         // 방어력
    public int HP { get; private set; }              // 체력
    public int Critical { get; private set; }        // 치명타 확률 또는 수치

    // 경험치 관련
    public int CurrentExp { get; private set; }      // 현재 경험치
    public int MaxExp { get; private set; }          // 다음 레벨까지 필요한 경험치

    // 인벤토리 및 장착 아이템
    public List<ItemData> Inventory { get; private set; }          // 플레이어가 소지한 아이템 목록
    private List<ItemData> equippedItems = new();                  // 현재 장착 중인 아이템 목록

    // 생성자: 캐릭터 초기 데이터 세팅
    public Character(string id, string job, int level, int gold,
        int attack, int defense, int hp, int critical, int currentExp)
    {
        Id = id;
        Job = job;
        Level = level;
        Gold = gold;

        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;

        CurrentExp = currentExp;
        MaxExp = level * 10;

        Inventory = new List<ItemData>();
    }

    // 아이템을 인벤토리에 추가
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    // 아이템 장착: 중복 장착 방지, 스탯 적용
    public void Equip(ItemData item)
    {
        if (!equippedItems.Contains(item))
        {
            equippedItems.Add(item);
            Attack += item.attack;
            Defense += item.defense;
            HP += item.hp;
            Critical += item.critical;
        }
    }

    // 아이템 장착 해제: 스탯 원상 복구
    public void UnEquip(ItemData item)
    {
        if (equippedItems.Contains(item))
        {
            equippedItems.Remove(item);
            Attack -= item.attack;
            Defense -= item.defense;
            HP -= item.hp;
            Critical -= item.critical;
        }
    }

    // 해당 아이템이 현재 장착 중인지 여부 확인
    public bool IsEquipped(ItemData item)
    {
        return equippedItems.Contains(item);
    }

    // 경험치 추가 및 레벨업 처리
    public void AddExp(int amount)
    {
        CurrentExp += amount;
        while (CurrentExp >= MaxExp)
        {
            CurrentExp -= MaxExp;
            Level++;
            MaxExp = Level * 10;
        }
    }
}
