using UnityEngine;

namespace InventorySystem.ItemCore
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public Texture2D icon;
        public string itemName;
        public string description;
        public int id;
        public bool stackable;

        public Item(Texture2D icon, string itemName, string description, int id, bool stackable)
        {
            this.icon = icon;
            this.itemName = itemName;
            this.description = description;
            this.id = id;
            this.stackable = stackable;
        }

        public Item(Item baseItem)
        {
            this.icon = baseItem.icon;
            this.itemName = baseItem.itemName;
            this.description = baseItem.description;
            this.id = baseItem.id;
            this.stackable = baseItem.stackable;
        }
        
    }
}
