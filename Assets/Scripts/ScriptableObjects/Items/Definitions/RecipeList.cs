using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe List", menuName = "Items/Crafting/Recipe List")]
public class RecipeList : ScriptableObject
{
  public List<CraftingRecipe> recipesList;
}
