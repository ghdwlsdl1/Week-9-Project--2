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

    [Header("아이템 아이콘")]
    public Sprite icon;
}
