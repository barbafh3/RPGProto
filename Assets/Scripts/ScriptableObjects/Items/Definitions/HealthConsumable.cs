using UnityEngine;

[CreateAssetMenu(fileName = "New Health Consumable", menuName = "Items/Consumables/Health")]
public class HealthConsumable : Item
{

  public FloatVariable playerHealth;

  public float amount;

  public override void UseItem(GameObject slotObj)
  {
    var slot = slotObj.GetComponent<InventorySlot>();
    playerHealth.Value += amount;
    itemEvent.Raise();
    slot.itemStack.Pop();
    slot.stackEvent.Raise();
    if (slot.itemStack.Count <= 0)
    {
      slot.RemoveItem();
    }
  }

}
