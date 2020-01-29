using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftSlot : Slot
{

    public InventoryList craftList; // Comment

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }

    public override void RemoveItem()
    {
        craftList.SetNullAt(itemIndex);
        ClearSlot();
        if (stackEvent != null)
            stackEvent.Raise();
        itemList.itemEvent.Raise();
    }

    public override void SwapItems(Slot callingSlot)
    {
        var localItemStack = itemStack;
        var incomingStack = callingSlot.itemStack;

        RemoveItem();
        callingSlot.RemoveItem();

        AddItem(incomingStack);
        craftList.AddAt(itemIndex, incomingStack);
        if (localItemStack != null && localItemStack.Peek().type == slotType)
        {
            callingSlot.AddItem(localItemStack);
            itemList.AddAt(callingSlot.itemIndex, localItemStack);
            craftList.itemEvent.Raise();
        }
        else
        {
            callingSlot.RemoveItem();
            itemList.itemEvent.Raise();
        }
        stackEvent.Raise();
    }

    public void SetItemCount()
    {
        var stack = CheckIfContains();
        if (stack != null)
        {
            if (stack.Count > 1)
            {
                stackCount.enabled = true;
                stackCount.text = stack.Count.ToString();
            }
            else
            {
                stackCount.enabled = false;
            }
        }
    }

    public Stack<Item> CheckIfContains()
    {
        Stack<Item> foundStack = null;
        foreach (Stack<Item> stack in craftList.Items)
        {
            if (stack != null)
            {
                var contains = stack.Contains(item);
                if (contains)
                {
                    foundStack = stack;
                    break;
                }
            }
        }
        return foundStack;
    }

}
