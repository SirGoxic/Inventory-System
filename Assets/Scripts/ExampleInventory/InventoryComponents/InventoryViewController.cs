using InventorySystem.SlotCore;
using InventorySystem.StorageCore;
using UnityEngine;

public class InventoryViewController : StorageView
{
    
    public Object slotPref;
    public Transform slotParent;

    public override void CreateView(int slotsCount)
    {
        for(int i = 0; i < slotsCount; i++){
            GameObject tempGO = (GameObject) Instantiate(slotPref, Vector3.zero, Quaternion.identity, slotParent);
            SlotViewComponent svc = tempGO.GetComponent<InventorySlotViewComponent>();
            slotViews.Add(svc);
        }
    }
}
