using UnityEngine;

public class MaterialController : ItemController
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
      PickUp();
  }
}
