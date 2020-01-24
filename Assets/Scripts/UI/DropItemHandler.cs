using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropItemHandler : MonoBehaviour, IDropHandler
{

  public InventoryList itemList;

  [SerializeField]
  protected GameObject icon;

  [SerializeField]
  protected Slot slot = null;

  protected InventoryUI _inventoryUI;

  public ItemType slotType;

  void Start()
  {
    _inventoryUI = transform.parent.parent.GetComponent<InventoryUI>();
  }

  public void OnDrop(PointerEventData eventData)
  {
    SwapItems(eventData);
  }

  public abstract void SwapItems(PointerEventData eventData);

}
