using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

  public Transform slotsParent;

  public List<InventorySlot> slots;

  [SerializeField]
  InventoryList inventory = null;

  bool _isInventoryOpen = false;

  public Animator inventoryAnim;

  void Start()
  {
    slots.AddRange(slotsParent.GetComponentsInChildren<InventorySlot>());
    for (int i = 0; i < slots.Count; i++)
    {
      slots[i].itemIndex = i;
    }
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      ToggleInventory();
    }
    if (Input.GetKeyDown(KeyCode.Escape) && _isInventoryOpen)
    {
      inventoryAnim.Play("InventorySlideOut");
      _isInventoryOpen = false;
    }
  }

  void ToggleInventory()
  {
    if (_isInventoryOpen)
    {
      inventoryAnim.Play("InventorySlideOut");
      _isInventoryOpen = false;
    }
    else
    {
      inventoryAnim.Play("InventorySlideIn");
      _isInventoryOpen = true;
    }
  }

  public void UpdateInventoryUI()
  {
    for (int i = 0; i < slots.Count; i++)
    {
      if (inventory.Items[i] != null)
        slots[i].AddItem(inventory.Items[i]);
    }
  }


}
