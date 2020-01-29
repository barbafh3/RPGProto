using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }

    void Update()
    {
        if (itemList.Items[itemIndex] == null || itemList.Items[itemIndex].Count == 0)
            RemoveItem();
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
        foreach (Stack<Item> stack in itemList.Items)
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
