using System.Collections.Generic;
using UnityEngine;

public abstract class ItemController : MonoBehaviour
{

  public InventoryList inventory = null;

  public Stack<Item> itemStack;

  public Item item;

  public GameEvent stackEvent;

  void Start()
  {
    itemStack = new Stack<Item>();
    if (item != null)
      itemStack.Push(item);
  }

  public virtual void PickUp()
  {
    bool wasPickedUp = AddItem();
    if (wasPickedUp)
      Destroy(gameObject);
  }

  public virtual bool AddItem()
  {

    var stack = CheckIfContains(item);
    if (stack != null)
    {
      stack.Push(item);
      itemStack = stack;
      stackEvent.Raise();
      return true;
    }
    else
    {
      var availableSlots = CheckAvailableSlots();
      if (availableSlots.Count > 0)
      {
        stack = new Stack<Item>();
        stack.Push(item);
        itemStack = stack;
        inventory.AddAt(availableSlots[0], stack);

        inventory.itemEvent.Raise();

        return true;
      }
      else
      {
        return false;
      }
    }
  }

  public Stack<Item> CheckIfContains(Item newItem)
  {
    Stack<Item> foundStack = null;
    foreach (Stack<Item> stack in inventory.Items)
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

  public List<int> CheckAvailableSlots()
  {
    var available = new List<int>();
    for (int i = 0; i <= inventory.Items.Count - 1; i++)
    {
      if (inventory.Items[i] == null) available.Add(i);
    }
    return available;
  }


}
