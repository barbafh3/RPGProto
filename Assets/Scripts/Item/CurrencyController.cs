using UnityEngine;

public class CurrencyController : ItemController
{

  public FloatVariable currency;

  public GameEvent coinEvent;

  public override void PickUp()
  {
    currency.Value++;
    coinEvent.Raise();
    Destroy(gameObject);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      PickUp();
    }
  }
}
