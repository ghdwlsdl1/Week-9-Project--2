public class Item
{
    public string itemName;
    public bool isEquipped;

    public Item(string name, bool equipped = false)
    {
        itemName = name;
        isEquipped = equipped;
    }
}
