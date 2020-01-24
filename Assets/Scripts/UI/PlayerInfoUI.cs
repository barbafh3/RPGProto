using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{

  public TextMeshProUGUI healthText;

  public TextMeshProUGUI currencyText;

  public FloatVariable playerHealth;

  public FloatVariable playerCurrency;

  public void RefreshPlayerInfo()
  {
    healthText.text = playerHealth.Value.ToString();
    currencyText.text = playerCurrency.Value.ToString();
  }

}
