using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropCraft : DropItemHandler
{

  public InventoryList craftList;

  public override void SwapItems(PointerEventData eventData)
  {
    var draggedObj = eventData.pointerDrag;
    if (draggedObj != null)
    {
      var inventorySlot = eventData.pointerDrag.GetComponent<Slot>();
      if (inventorySlot.icon.GetComponent<Image>().enabled)
      {
        if (inventorySlot.itemStack.Peek().type == slotType)
        {
          Stack<Item> localItemStack = slot.itemStack;

          var dragItem = draggedObj.GetComponent<DragItem>();
          slot.RemoveItem();
          slot.AddItem(inventorySlot.itemStack);
          craftList.AddAt(slot.itemIndex, inventorySlot.itemStack);
          inventorySlot.RemoveItem();
          dragItem.SetDragVariables(1f, true, dragItem.defaultIconParent);
          if (localItemStack != null && localItemStack.Peek().type == slotType)
          {
            inventorySlot.AddItem(localItemStack);
            itemList.AddAt(inventorySlot.itemIndex, localItemStack);
          }

          if (inventorySlot.stackEvent != null)
          {
            inventorySlot.stackEvent.Raise();
          }
        }
      }
    }
  }
}
