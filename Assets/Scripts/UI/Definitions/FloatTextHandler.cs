using UnityEngine;
using TMPro;

public class FloatTextHandler : MonoBehaviour
{

  public TextMeshProUGUI textField;

  public FloatVariable floatValue;

  public virtual void RefreshText()
  {
    textField.text = floatValue.Value.ToString();
  }

}
