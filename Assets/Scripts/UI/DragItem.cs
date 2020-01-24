using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler
{

  [SerializeField]
  private GameObject icon = null;

  private Image _image;

  private CanvasGroup _iconCanvasGroup;

  public Transform defaultIconParent;

  private Transform _canvas;

  void Start()
  {
    _image = icon.GetComponent<Image>();
    _iconCanvasGroup = icon.GetComponent<CanvasGroup>();
    _canvas = icon.transform.parent.parent.parent.parent;
  }

  void Update() { }

  public void OnDrag(PointerEventData eventData)
  {
    if (_image.enabled)
    {
      SetDragVariables(0.6f, false, _canvas);
      icon.transform.position = Input.mousePosition;
    }
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    SetDragVariables(1f, true, defaultIconParent);
    icon.transform.localPosition = Vector2.zero;
  }

  public void SetDragVariables(float alpha, bool targetable, Transform parent)
  {
    _iconCanvasGroup.alpha = alpha;
    _iconCanvasGroup.blocksRaycasts = targetable;
    icon.transform.SetParent(parent, true);
  }
}
