using System.Collections.Generic;
using InventorySystem.ItemCore;
using InventorySystem.SlotCore;
using UnityEngine;

namespace InventorySystem.StorageCore
{
    public class Storage : MonoBehaviour
    {
        public Slot[] slots;
        private List<int> emptySlots = new List<int>();

        public void InicSlots(int slotsCount)
        {
            slots = new Slot[slotsCount];
            for (int i = 0; i < slots.Length; i++)
            {
                emptySlots.Add(i);
                slots[i] = new Slot();
            }
        }

        public void ClearSlot(int index)
        {
            slots[index].ClearSlot();
            emptySlots.Add(index);
        }

        public bool TryToAddItem(Item item, int count, ref int slotIndex)
        {
            int index = -1;

            if (item.stackable)
            {
                //If neither of slots, does not contain current item
                if ((index = FindAtItem(item)) == -1)
                {
                    //Try to find empty slot
                    if (emptySlots.Count > 0)
                    {
                        index = emptySlots[0];
                        emptySlots.RemoveAt(0);
                    }
                    else
                    {
                        slotIndex = index;
                        
                        return false;
                    }
                    
                    //Add to item

                    slots[index].AddItem(item, count);
                    
                    slotIndex = index;
                    
                    return true;
                }
                else
                {
                    //Just add item
                    slots[index].AddItem(item, count);

                    slotIndex = index;
                    
                    return true;
                }
            }
            else
            {
                //If item is not stackable, try to add all item in empty slots
                for (int i = 0; i < count; i++)
                {
                    if (emptySlots.Count > 0)
                    {
                        index = emptySlots[0];
                        emptySlots.RemoveAt(0);

                        slots[index].AddItem(item, 1);
                    }
                    else
                    {
                        slotIndex = index;
                        
                        return false;
                    }
                }
                
                slotIndex = index;
                
                return true;
            }
        }

        public bool TryToRemoveItem(Item item, int count)
        {
            if (count > 0)
            {

                int index = FindAtItem(item);

                if (index != -1)
                {

                    if (count == 1)
                    {
                        slots[index].DicreaseCount();
                    }
                    else
                    {
                        slots[index].DicreaseCount(count);
                    }

                    if (slots[index].IsEmpty())
                    {
                        emptySlots.Add(index);
                    }

                    return true;
                }
            }

            return false;
        }

        public bool TryToRemoveItem(int id, int count)
        {
            if (count > 0)
            {

                int index = FindAtItem(id);

                if (index != -1)
                {

                    if (count == 1)
                    {
                        slots[index].DicreaseCount();
                    }
                    else
                    {
                        slots[index].DicreaseCount(count);
                    }
                    
                    if (slots[index].IsEmpty())
                    {
                        emptySlots.Add(index);
                    }

                    return true;
                }
            }

            return false;
        }

        public int FindAtItem(Item item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].GetItem() == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindAtItem(int id)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].GetItem().id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindAtSlot(Slot slot)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots.Equals(slot))
                {
                    return i;
                }
            }
            return -1;
        }

        public void SwapSlots(int slotIndex, int slotIndexNew)
        {

            if (emptySlots.Contains(slotIndex))
            {
                emptySlots.Remove(slotIndex);
                emptySlots.Add(slotIndexNew);
            }
            else if (emptySlots.Contains(slotIndexNew))
            {
                emptySlots.Remove(slotIndexNew);
                emptySlots.Add(slotIndex);
            }

            Slot tempSlot = slots[slotIndex];

            slots[slotIndex] = slots[slotIndexNew];
            slots[slotIndexNew] = tempSlot;
        }
    }
}
