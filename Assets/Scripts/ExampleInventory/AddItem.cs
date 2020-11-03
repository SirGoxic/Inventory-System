using System.Collections;
using System.Collections.Generic;
using InventorySystem.ItemCore;
using InventorySystem.StorageCore;
using UnityEngine;

public class AddItem : MonoBehaviour
{

    public Item item;
    public int count;

    public StorageController storageController;
    
    public void AddItemToStorage()
    {
        storageController.TryToAddItem(item, count);
    }
    
}
