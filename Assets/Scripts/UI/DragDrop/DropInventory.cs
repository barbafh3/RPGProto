using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropInventory : DropItemHandler
{

  public override void SwapItems(PointerEventData eventData)
  {
    var draggedObj = eventData.pointerDrag;
    if (draggedObj != null)
    {
      var inventorySlot = eventData.pointerDrag.GetComponent<Slot>();
      if (inventorySlot.icon.GetComponent<Image>().enabled)
      {
        var localItemStack = slot.itemStack;
        var incomingItem = inventorySlot.itemStack.Peek();
        var dragItem = draggedObj.GetComponent<DragItem>();
        if (localItemStack != null)
        {
          var localItem = localItemStack.Peek();

          if (inventorySlot.slotType is EquipmentType)
          {
            if (localItem.type == incomingItem.type)
            {
              DoSwap(inventorySlot, localItemStack, dragItem);
            }
          }
          else
          {
            DoSwap(inventorySlot, localItemStack, dragItem);
          }
        }
        else
        {
          DoSwap(inventorySlot, localItemStack, dragItem);
        }
      }
    }
  }

  private void DoSwap(Slot inventorySlot, Stack<Item> localItemStack, DragItem dragItem)
  {
    slot.RemoveItem();
    slot.AddItem(inventorySlot.itemStack);
    itemList.AddAt(slot.itemIndex, inventorySlot.itemStack);
    slot.stackEvent.Raise();
    inventorySlot.RemoveItem();
    dragItem.SetDragVariables(1f, true, dragItem.defaultIconParent);
    if (localItemStack != null)
    {
      inventorySlot.AddItem(localItemStack);
      itemList.AddAt(inventorySlot.itemIndex, localItemStack);
    }
    if (inventorySlot.stackEvent != null)
      inventorySlot.stackEvent.Raise();
  }
}
