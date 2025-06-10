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
}
