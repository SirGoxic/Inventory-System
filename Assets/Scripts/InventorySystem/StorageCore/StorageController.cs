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
            storageView.CreateView(slotsCount);
            UpdateView();
        }

        public void UpdateView()
        {
            for (int i = 0; i < storage.slots.Length; i++)
            {
                storageView.UpdateSlotView(i, storage.slots[i].GetItem(), storage.slots[i].GetItemCount());
            }
        }
        public void UpdateView(int slotIndex)
        {
            if (slotIndex >= 0)
            {
                storageView.UpdateSlotView(slotIndex, storage.slots[slotIndex].GetItem(), storage.slots[slotIndex].GetItemCount());
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
            bool result = storage.TryToAddItem(item, count);

            UpdateView();

            return result;
        }

        public bool TryToAddItem(int id, int count)
        {
            Item tempItem = itemList.GetItem(id);
            bool result = storage.TryToAddItem(tempItem, count);

            UpdateView();

            return result;
        }

        public bool TryToAddItemInSlot(Item item, int count, int slotIndex)
        {
            bool result = storage.TryToAddItemInSlot(item, count, slotIndex);

            UpdateView();

            return result;
        }
        
        public bool TryToAddItemInSlot(int id, int count, int slotIndex)
        {
            Item tempItem = itemList.GetItem(id);
            bool result = storage.TryToAddItemInSlot(tempItem, count, slotIndex);

            UpdateView();

            return result;
        }

        public bool TryToRemoveItem(Item item, int count, ref int restCount)
        {
            bool result = storage.TryToRemoveItem(item, count, ref restCount);
            UpdateView();

            return result;
        }

        public bool TryToRemoveItem(int id, int count, ref int restCount)
        {
            bool result = storage.TryToRemoveItem(itemList.GetItem(id), count, ref restCount);
            UpdateView();

            return result;
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
