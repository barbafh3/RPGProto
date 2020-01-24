using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

  [SerializeField]
  InventoryList inventory = null;

  [SerializeField]
  InventoryList equipment = null;

  public float inventorySize;

  private int _equipmentSize = 3;

  void Start()
  {
    ClearInventory();
    FillInventoryAndEquipment();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.B))
    {
      foreach (Stack<Item> stack in inventory.Items)
      {
        Debug.Log(stack);
      }
    }
  }

  private void ClearInventory()
  {
    for (int i = 0; i < inventory.Items.Count; i++)
    {
      inventory.Items[i] = null;
    }
  }

  private void FillInventoryAndEquipment()
  {
    for (int i = 0; i < inventorySize; i++)
    {
      inventory.ForceAdd(null);
    }

    for (int i = 0; i < _equipmentSize; i++)
    {
      equipment.ForceAdd(null);
    }
  }
}
