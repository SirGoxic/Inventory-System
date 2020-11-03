# Unity Inventory System

This is a simple core of **Inventory System** for any game.


## Setup
1. Import unitypackage
2. Create some script
  - **That should inherit _SlotViewComponent_ script**
  - **Implemet void _UpdateSlotView(Item item, int count)_**
  - Here you can write how your component should update it self view
  - Example: 
  ```
  public override void UpdateSlotView(Item item, int count)
  {
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
  ```
3. Create another script
  - **That should inherit _StorageView_ script**
  - **Implemet void _CreateView()_**
  - Here you can write how your view is creating
  - Example:
  ```
  public override void CreateView()
  {
  //slotParent - is a UI panel which contain Grid Layout Group component
  //slotViews - is a list of all SlotViewComponents which linked with slot's list index by index
      for(int i = 0; i < slotsCount; i++){
          GameObject tempGO = (GameObject) Instantiate(slotPref, Vector3.zero, Quaternion.identity, slotParent);
          SlotViewComponent svc = tempGO.GetComponent<InventoryViewComponent>();
          slotViews.Add(svc);
      }
  }
  ```
4. Add some Items in any folder and customize them
5. Add errorItem, this item used for some error requests
6. Scene setup
  - Add on your scene Storage, your StorageView, StorageController and ItemList
    - Item list is needed to manage items by id
  - Fill StorageController and ItemList
  - Create Slot prefab
    - It should contain your SlotViewComponent
  - Setup your StorageView
7. Thats all, you can use it.
  
## Warning
**You should manage storage via _StorageController_ to avoid mistakes!**
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
