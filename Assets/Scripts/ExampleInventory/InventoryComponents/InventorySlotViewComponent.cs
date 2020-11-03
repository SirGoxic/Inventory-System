using InventorySystem.ItemCore;
using InventorySystem.SlotCore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotViewComponent : SlotViewComponent
{
    public RawImage icon;
    public TMP_Text count;
    
    public override void UpdateSlotView(Item item, int count)
    {
        if (item == null)
        {
            icon.enabled = false;
            this.count.gameObject.SetActive(false);
            this.count.text = "";
            return;
        }
        
        if (item.icon == null)
        {
            icon.enabled = false;
        }
        else
        {
            icon.enabled = true;
        }

        icon.texture = item.icon;

        if (count > 1)
        {
            this.count.gameObject.SetActive(true);
            this.count.text = count.ToString();
        }
        else
        {
            this.count.gameObject.SetActive(false);
            this.count.text = "";
        }
    }
}
