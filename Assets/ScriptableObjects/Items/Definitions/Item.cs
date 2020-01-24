using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{

  public string itemName = "New Item";

  public Sprite icon = null;

  public ItemType type;

  public GameEvent itemEvent;

  public abstract void UseItem(GameObject slotObj);

  public List<int> CheckAvailableSlots(InventoryList inv)
  {
    var available = new List<int>();
    for (int i = 0; i < inv.Items.Count; i++)
    {
      if (inv.Items[i] == null) available.Add(i);
    }
    return available;
  }

  public InventorySlot FindInventorySlotWithIndex(int index)
  {
    var list = GameObject.FindObjectsOfType<InventorySlot>();
    InventorySlot targetSlot = null;
    foreach (InventorySlot slot in list)
    {
      if (slot.itemIndex == index)
      {
        targetSlot = slot;
        break;
      }
    }
    return targetSlot;
  }

}
