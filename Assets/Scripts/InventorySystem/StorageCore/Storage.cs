using System.Collections.Generic;
using InventorySystem.ItemCore;
using InventorySystem.SlotCore;
using UnityEngine;

namespace InventorySystem.StorageCore
{
    public class Storage : MonoBehaviour
    {
        [HideInInspector]
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
            emptySlots.Sort();
        }

        public bool TryToAddItem(Item item, int count)
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

                        return false;
                    }
                    
                    //Add to item

                    slots[index].AddItem(item, count);
                    
                    
                    return true;
                }
                else
                {
                    //Just add item
                    slots[index].AddItem(item, count);
                    
                    
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

                        return false;
                    }
                }

                return true;
            }
        }
        
        public bool TryToAddItemInSlot(Item item, int count, int slotIndex)
        {
            if (item.stackable)
            {
                //If neither of slots, does not contain current item
                if (slots[slotIndex].GetItem() == item)
                {
                    slots[slotIndex].AddItem(item, count);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (slots[slotIndex].IsEmpty())
                {
                    slots[slotIndex].AddItem(item, 1);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TryToRemoveItem(Item item, int count, ref int restCount)
        {
            if (count > 0)
            {

                if (item.stackable)
                {
                    int index = -1;
                    
                    while (count > 0)
                    {
                        index = FindAtItem(item);
                        if (index != -1)
                        {

                            int tempCount = slots[index].GetItemCount();
                            
                            slots[index].DicreaseCount(count);

                            count -= tempCount;

                            if (count < 0)
                            {
                                count = 0;
                            }
                            
                            if (slots[index].IsEmpty())
                            {
                                emptySlots.Add(index);
                                emptySlots.Sort();
                            }
                        }
                        else
                        {
                            restCount = count;
                            return false;
                        }
                    }
                    restCount = count;
                    return true;
                }
                else
                {
                    int index = -1;
                    
                    while (count > 0)
                    {
                        index = FindAtItem(item);
                        if (index != -1)
                        {

                            slots[index].DicreaseCount();

                            count--;
                            
                            if (slots[index].IsEmpty())
                            {
                                emptySlots.Add(index);
                                emptySlots.Sort();
                            }
                        }
                        else
                        {
                            restCount = count;
                            return false;
                        }
                    }
                    restCount = count;
                    return true;
                }

            }
            restCount = count;
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
                emptySlots.Add(slotIndex);
                emptySlots.Sort();
            }
            else if (emptySlots.Contains(slotIndexNew))
            {
                emptySlots.Remove(slotIndexNew);
                emptySlots.Add(slotIndex);
                emptySlots.Sort();
            }

            Slot tempSlot = slots[slotIndex];

            slots[slotIndex] = slots[slotIndexNew];
            slots[slotIndexNew] = tempSlot;
        }
    }
}
