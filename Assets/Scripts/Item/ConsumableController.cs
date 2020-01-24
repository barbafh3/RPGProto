using System;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : ItemController
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
      PickUp();
  }

  public override void PickUp()
  {
    bool wasPickedUp = AddItem();
    if (wasPickedUp)
      Destroy(gameObject);
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

  public override bool AddItem()
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

}
