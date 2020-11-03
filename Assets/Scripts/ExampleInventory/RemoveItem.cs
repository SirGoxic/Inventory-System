using System.Collections;
using System.Collections.Generic;
using InventorySystem.ItemCore;
using InventorySystem.StorageCore;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public Item item;
    public int count;

    public StorageController storageController;
    
    public void RemoveItemFromStorage()
    {
        int restCount = 0;
        storageController.TryToRemoveItem(item, count, ref restCount);
    }
}
