using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{

  public FloatVariable currency;

  public GameEvent currencyCHangeEvent;

  void Start()
  {
    currencyCHangeEvent.Raise();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void AddHealth(float amount)
  {
    currency.Value += amount;
    currencyCHangeEvent.Raise();
  }

  void RemoveHealth(float amount)
  {
    currency.Value -= amount;
    currencyCHangeEvent.Raise();
  }

}
