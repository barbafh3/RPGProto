using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyHandler : FloatTextHandler
{
  public override void RefreshText()
  {
    textField.text = floatValue.Value.ToString();
  }
}
