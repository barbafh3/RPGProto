using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUI : MonoBehaviour
{

  public Animator equipAnim;

  bool _isEquipOpen;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      if (_isEquipOpen)
      {
        equipAnim.Play("EquipSlideOut");
        _isEquipOpen = false;
      }
      else
      {
        equipAnim.Play("EquipSlideIn");
        _isEquipOpen = true;
      }
    }
    if (Input.GetKeyDown(KeyCode.Escape) && _isEquipOpen)
    {
      equipAnim.Play("EquipSlideOut");
      _isEquipOpen = false;
    }
  }
}
