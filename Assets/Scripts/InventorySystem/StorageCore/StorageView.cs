using System.Collections.Generic;
using InventorySystem.SlotCore;
using UnityEngine;

namespace InventorySystem.StorageCore
{
    public abstract class StorageView : MonoBehaviour
    {

        protected List<SlotViewComponent> slotViews = new List<SlotViewComponent>();

        public abstract void CreateView();

        public void UpdateSlotView(int index, Texture2D icon, int count)
        {
            slotViews[index].UpdateSlotView(icon, count);
        }
    }
}
