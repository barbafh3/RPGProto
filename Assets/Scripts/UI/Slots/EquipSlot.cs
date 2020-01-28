using UnityEngine.EventSystems;

public class EquipSlot : Slot, IPointerClickHandler
{

  public InventoryList equipment;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (eventData.button == PointerEventData.InputButton.Right)
    {
      UseItem();
    }
  }

  public override void SwapItems(Slot callingSlot)
  {
    var localItemStack = itemStack;
    var incomingStack = callingSlot.itemStack;

    RemoveItem();
    callingSlot.RemoveItem();

    AddItem(incomingStack);
    equipment.AddAt(itemIndex, incomingStack);
    if (localItemStack != null && localItemStack.Peek().type == slotType)
    {
      callingSlot.AddItem(localItemStack);
      itemList.AddAt(callingSlot.itemIndex, localItemStack);
      equipment.itemEvent.Raise();
    }
    else
    {
      callingSlot.RemoveItem();
      itemList.itemEvent.Raise();
    }
  }

  public override void RemoveItem()
  {
    equipment.SetNullAt(itemIndex);
    ClearSlot();
    if (stackEvent != null)
      stackEvent.Raise();
    itemList.itemEvent.Raise();
  }

}
