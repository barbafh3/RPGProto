using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{

  public Animator craftAnim;

  bool _isCraftOpen;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      if (_isCraftOpen)
      {
        craftAnim.Play("CraftSlideOut");
        _isCraftOpen = false;
      }
      else
      {
        craftAnim.Play("CraftSlideIn");
        _isCraftOpen = true;
      }
    }
    if (Input.GetKeyDown(KeyCode.Escape) && _isCraftOpen)
    {
      craftAnim.Play("CraftSlideOut");
      _isCraftOpen = false;
    }
  }
}
