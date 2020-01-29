using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Craft Material", menuName = "Items/Crafting/Material")]
public class CraftingMaterial : Item
{

  public override void UseItem(GameObject callingSlotObj)
  {
    var drop = callingSlotObj.GetComponent<DropItemHandler>();
    if (drop.slotType != type)
    {
      InventorySlot slot = callingSlotObj.GetComponent<InventorySlot>();
      var craftingSlots = GameObject.FindGameObjectsWithTag("Crafting Slot");
      CraftSlot craftSlot = null;
      foreach (GameObject cSlot in craftingSlots)
      {
        if (cSlot.transform.GetChild(0).GetComponent<Image>().enabled == false)
        {
          craftSlot = cSlot.GetComponent<CraftSlot>();
          break;
        }
      }
      if (craftSlot == null)
        craftSlot = craftingSlots[0].GetComponent<CraftSlot>();
      var craftSlotScript = craftSlot.GetComponent<CraftSlot>();

      craftSlotScript.SwapItems(slot);
    }
    else
    {
      Debug.Log("Swapping out");
      CraftSlot slot = callingSlotObj.GetComponent<CraftSlot>();
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
        slot.craftList.AddAt(slot.itemIndex, targetStack);
      }

      if (slot.stackEvent != null)
        slot.stackEvent.Raise();

      slot.itemList.itemEvent.Raise();
      slot.craftList.itemEvent.Raise();
    }
  }

}