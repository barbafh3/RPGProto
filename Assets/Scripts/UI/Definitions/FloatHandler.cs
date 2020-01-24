using UnityEngine;

public class FloatHandler : MonoBehaviour
{

  [SerializeField]
  private FloatVariable floatValue = null;

  [SerializeField]
  private float startingValue = 0f;

  [SerializeField]
  private GameEvent changeValueEvent = null;

  void Start()
  {
    floatValue.Value = startingValue;
    changeValueEvent.Raise();
  }

  public void RaiseValue(float amount)
  {
    floatValue.Value += amount;
    changeValueEvent.Raise();
  }

  public void ReduceValue(float amount)
  {
    floatValue.Value -= amount;
    changeValueEvent.Raise();
  }
}
