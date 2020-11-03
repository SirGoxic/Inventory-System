using InventorySystem.ItemCore;
using InventorySystem.SlotCore;
using UnityEngine;

namespace InventorySystem.StorageCore
{
    public class StorageController : MonoBehaviour
    {
        public int slotsCount;
        
        public Storage storage;
        public StorageView storageView;

        public ItemList itemList;

        public void Start()
        {
            storage.InicSlots(slotsCount);
            storageView.CreateView();
            UpdateView();
        }

        public void UpdateView()
        {
            for (int i = 0; i < storage.slots.Length; i++)
            {
                if (!storage.slots[i].IsEmpty())
                {
                    storageView.UpdateSlotView(i, storage.slots[i].GetItem().icon, storage.slots[i].GetItemCount());
                }
            }
        }
        public void UpdateView(int slotIndex)
        {
            if (slotIndex >= 0)
            {
                storageView.UpdateSlotView(slotIndex, storage.slots[slotIndex].GetItem().icon, storage.slots[slotIndex].GetItemCount());
            }
        }

        public Item GetItem(int slotIndex)
        {
            if (storage.slots[slotIndex].IsEmpty())
            {
                return itemList.errorItem;
            }
            return storage.slots[slotIndex].GetItem();
        }

        public bool TryToAddItem(Item item, int count)
        {
            int slotIndex = -1;
            bool result = storage.TryToAddItem(item, count, ref slotIndex);

            if (result)
            {
                UpdateView(slotIndex);
            }

            return result;
        }

        public bool TryToAddItem(int id, int count)
        {
            Item tempItem = itemList.GetItem(id);
            int slotIndex = -1;
            bool result = storage.TryToAddItem(tempItem, count, ref slotIndex);

            if (result)
            {
                UpdateView(slotIndex);
            }

            return result;
        }

        public bool TryToRemoveItem(Item item, int count)
        {
            return storage.TryToRemoveItem(item, count);
        }

        public bool TryToRemoveItem(int id, int count)
        {
            return storage.TryToRemoveItem(id, count);
        }

        public int FindAtSlot(Slot slot)
        {
            return storage.FindAtSlot(slot);
        }

        public void ClearSlot(int slotIndex)
        {
            storage.ClearSlot(slotIndex);
        }

        public void SwapSlots(int slotIndex, int slotIndexNew)
        {
            storage.SwapSlots(slotIndex, slotIndexNew);
        }
    }
}
