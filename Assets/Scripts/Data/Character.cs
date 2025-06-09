using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Id { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }

    public Character(string id, int level, int gold)
    {
        Id = id;
        Level = level;
        Gold = gold;
    }
}
