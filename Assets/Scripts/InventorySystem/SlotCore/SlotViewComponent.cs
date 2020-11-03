using UnityEngine;

namespace InventorySystem.SlotCore
{

    public abstract class SlotViewComponent : MonoBehaviour
    {

        public abstract void UpdateSlotView(Texture2D icon, int count);
    }
}
