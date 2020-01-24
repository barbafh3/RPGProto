using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item
{

  public override void UseItem(GameObject callingSlotObj)
  {
    var drop = callingSlotObj.GetComponent<DropItemHandler>();
    if (drop.slotType != type)
    {
      InventorySlot slot = callingSlotObj.GetComponent<InventorySlot>();
      GameObject weaponSlot = null;
      switch (type.typeName)
      {
        case "Weapon":
          {
            weaponSlot = GameObject.FindGameObjectWithTag("Weapon Slot");
            break;
          }
        case "Armor":
          {
            weaponSlot = GameObject.FindGameObjectWithTag("Armor Slot");
            break;
          }
        case "Helmet":
          {
            weaponSlot = GameObject.FindGameObjectWithTag("Helmet Slot");
            break;
          }
      }
      var weaponSlotScript = weaponSlot.GetComponent<EquipSlot>();

      weaponSlotScript.SwapItems(slot);
    }
    else
    {
      EquipSlot slot = callingSlotObj.GetComponent<EquipSlot>();
      List<int> availableSlots = CheckAvailableSlots(slot.itemList);
      var targetSlot = FindInventorySlotWithIndex(availableSlots[0]);

      var targetStack = targetSlot.itemStack;
      var localStack = slot.itemStack;

      slot.itemList.AddAt(availableSlots[0], slot.itemStack);
      if (targetSlot != null)
      {
        targetSlot.RemoveItem();
        targetSlot.AddItem(localStack);
        slot.itemList.AddAt(targetSlot.itemIndex, localStack);
      }

      slot.RemoveItem();

      slot.itemList.itemEvent.Raise();

      if (targetStack != null)
      {
        slot.AddItem(targetStack);
        slot.equipment.AddAt(slot.itemIndex, targetStack);
      }

      if (slot.stackEvent != null)
        slot.stackEvent.Raise();

      slot.itemList.itemEvent.Raise();
      slot.equipment.itemEvent.Raise();
    }
  }
}
