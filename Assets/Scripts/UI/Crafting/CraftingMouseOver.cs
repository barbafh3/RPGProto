using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CraftingMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

  [SerializeField]
  GameObject craftItemInfoPanel = null;

  [SerializeField]
  Item item = null;

  [SerializeField]
  CraftingRecipe recipe = null;

  [SerializeField]
  TextMeshProUGUI itemNameText = null;

  [SerializeField]
  GameObject materialPrefab = null;

  GameObject materials;

  void Start()
  {
    materials = craftItemInfoPanel.transform.GetChild(1).gameObject;
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    Debug.Log("Entered");
    craftItemInfoPanel.SetActive(true);
    LoadInfo();
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    Debug.Log("Exited");
    craftItemInfoPanel.SetActive(false);
    ClearInfo();
  }

  void LoadInfo()
  {
    itemNameText.text = item.name;
    List<CraftingMaterial> matList = new List<CraftingMaterial>();

    foreach (CraftingMaterial material in recipe.materialList)
    {
      if (!matList.Contains(material)) matList.Add(material);
    }

    foreach (CraftingMaterial material in matList)
    {
      CreateMaterialPrefab(material);
    }
  }

  private void CreateMaterialPrefab(CraftingMaterial material)
  {
    var materialCount = recipe.materialList.FindAll(m => m == material).Count;
    var materialObj = Instantiate(materialPrefab, materials.transform.position, Quaternion.identity);
    materialObj.transform.parent = materials.transform;
    var materialObjIcon = materialObj.transform.GetChild(0);
    var materialObjText = materialObj.transform.GetChild(1);
    materialObjIcon.GetComponent<Image>().sprite = material.icon;
    materialObjText.GetComponent<TextMeshProUGUI>().text = materialCount.ToString();
  }

  void ClearInfo()
  {
    foreach (Transform child in materials.transform)
    {
      Destroy(child.gameObject);
    }
  }

}
