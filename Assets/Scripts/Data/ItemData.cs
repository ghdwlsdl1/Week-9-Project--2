using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;

    [Header("스탯 증가량")]
    public int attack;
    public int defense;
    public int hp;
    public int critical;
}
