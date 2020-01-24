using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory List", menuName = "Inventory/Inventory List")]
public class InventoryList : RuntimeSet<Stack<Item>>
{
  public GameEvent itemEvent;

  public override void SetNullAt(int i)
  {
    Items[i] = null;
  }
}
