using System.Collections.Generic;

public class Character
{
    public string Id { get; private set; }
    public string Job { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }

    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int HP { get; private set; }
    public int Critical { get; private set; }

    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }

    public List<ItemData> Inventory { get; private set; }
    private List<ItemData> equippedItems = new List<ItemData>();

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

    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

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

    public bool IsEquipped(ItemData item)
    {
        return equippedItems.Contains(item);
    }

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
