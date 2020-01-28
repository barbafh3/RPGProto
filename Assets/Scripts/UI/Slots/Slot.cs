using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Slot : MonoBehaviour
{

  public InventoryList itemList;

  public Image icon;

  public Stack<Item> itemStack;

  public Item item;

  public int itemIndex;

  public ItemType slotType;

  public TextMeshProUGUI stackCount = null;

  public GameEvent stackEvent = null;

  public virtual void UseItem()
  {
    if (itemStack != null)
    {
      itemStack.Peek().UseItem(gameObject);
    }
  }

  public virtual void AddItem(Stack<Item> newItemStack)
  {
    itemStack = newItemStack;
    item = itemStack.Peek();

    icon.sprite = itemStack.Peek().icon;
    icon.enabled = true;
  }

  public virtual void ClearSlot()
  {
    itemStack = null;
    item = null;
    icon.sprite = null;
    icon.enabled = false;
    if (stackCount != null)
      stackCount.text = "";
  }

  public virtual void RemoveItem()
  {
    itemList.SetNullAt(itemIndex);
    ClearSlot();
    if (stackEvent != null)
      stackEvent.Raise();
    itemList.itemEvent.Raise();
  }

  public virtual void SwapItems(Slot slot) { }

}
