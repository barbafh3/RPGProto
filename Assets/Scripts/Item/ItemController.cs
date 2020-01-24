using System.Collections;
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

  public abstract void PickUp();

  public virtual bool AddItem() { return false; }

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
