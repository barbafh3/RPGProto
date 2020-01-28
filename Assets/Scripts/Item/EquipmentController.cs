using UnityEngine;

public class EquipmentController : ItemController
{

  public InventoryList equipment;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
      PickUp();
  }

  // public override void PickUp()
  // {
  //   bool wasPickedUp = AddItem();
  //   if (wasPickedUp)
  //     Destroy(gameObject);
  // }

  public override bool AddItem()
  {
    var availableSlots = CheckAvailableSlots();
    if (availableSlots.Count > 0)
    {
      inventory.AddAt(availableSlots[0], itemStack);

      inventory.itemEvent.Raise();

      return true;
    }
    else
    {
      return false;
    }
  }

}
