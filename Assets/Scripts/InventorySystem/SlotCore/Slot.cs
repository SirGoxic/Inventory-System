using System;
using InventorySystem.ItemCore;
using UnityEngine;

namespace InventorySystem.SlotCore
{

    [Serializable]
    public class Slot
    {

        [SerializeField]
        private Item item = null;
        [SerializeField]
        private int itemCount = 0;

        public void AddItem(Item item, int itemCount)
        {
            if (this.item == item)
            {
                this.itemCount += itemCount;
            }
            else
            {
                this.item = item;
                this.itemCount = itemCount;
            }
        }
        
        public void AddItem(Item item)
        {
            if (this.item == item)
            {
                this.itemCount += 1;
            }
            else
            {
                this.item = item;
                this.itemCount = 1;
            }
        }

        public Item GetItem()
        {
            return item;
        }

        public int GetItemCount()
        {
            return itemCount;
        }

        public void ClearSlot()
        {
            item = null;
            itemCount = 0;
        }

        public int DicreaseCount()
        {
            itemCount--;
            if (itemCount == 0)
            {
                item = null;
            }
            return itemCount;
        }

        public int DicreaseCount(int amount)
        {
            itemCount -= amount;
            if (itemCount == 0)
            {
                item = null;
            }
            return itemCount;
        }

        public bool IsEmpty()
        {
            return !(itemCount > 0 && item != null);
        }

        public override string ToString()
        {
            string result = "Item:";
            if (item == null)
            {
                result += "null";
            }
            else
            {
                result += item.itemName;
            }

            result += "|Count:" + itemCount;

            return result;
        }
    }
}
