using UnityEngine;

public class ConsumableController : ItemController
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
      PickUp();
  }

}
