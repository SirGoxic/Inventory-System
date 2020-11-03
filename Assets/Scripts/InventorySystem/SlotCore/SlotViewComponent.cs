using InventorySystem.ItemCore;
using UnityEngine;

namespace InventorySystem.SlotCore
{

    public abstract class SlotViewComponent : MonoBehaviour
    {

        public abstract void UpdateSlotView(Item item, int count);
    }
}
