using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Items/Crafting/Recipe")]
public class CraftingRecipe : ScriptableObject
{

  public List<Item> materialList;

  public Item craftedItem;

}
