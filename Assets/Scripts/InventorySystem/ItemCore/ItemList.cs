using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.ItemCore
{
    public class ItemList : MonoBehaviour
    {
        public Item errorItem;
        [SerializeField]
        private List<Item> items = new List<Item>();

        public Item GetItem(int id)
        {
            foreach (Item item in items)
            {
                if (item.id == id)
                {
                    return item;
                }
            }

            return errorItem;
        }
    }
}
