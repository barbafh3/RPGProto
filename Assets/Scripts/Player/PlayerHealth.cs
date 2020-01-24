using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

  public float maxHealth;

  public FloatVariable currentHealth;

  public GameEvent healthChangeEvent;

  void Start()
  {
    currentHealth.Value = maxHealth;
    healthChangeEvent.Raise();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void AddHealth(float amount)
  {
    currentHealth.Value += amount;
    healthChangeEvent.Raise();
  }

  void RemoveHealth(float amount)
  {
    currentHealth.Value -= amount;
    healthChangeEvent.Raise();
  }
}
