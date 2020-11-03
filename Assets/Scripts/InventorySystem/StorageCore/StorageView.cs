using System.Collections.Generic;
using InventorySystem.ItemCore;
using InventorySystem.SlotCore;
using UnityEngine;

namespace InventorySystem.StorageCore
{
    public abstract class StorageView : MonoBehaviour
    {

        protected List<SlotViewComponent> slotViews = new List<SlotViewComponent>();

        public abstract void CreateView(int slotsCount);

        public void UpdateSlotView(int index, Item item, int count)
        {
            slotViews[index].UpdateSlotView(item, count);
        }
    }
}
