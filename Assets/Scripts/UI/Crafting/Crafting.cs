using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{

  [SerializeField]
  InventoryList inventory = null;

  [SerializeField]
  List<Slot> inventorySlots = null;

  [SerializeField]
  GameEvent stackedEvent = null;

  [SerializeField]
  CraftSlot slot1 = null;

  [SerializeField]
  CraftSlot slot2 = null;

  [SerializeField]
  RecipeList list = null;

  public void DoCraft()
  {
    CraftingRecipe recipe = CheckMaterials();

    if (recipe != null)
    {
      int material1Count = CountOcurrences(recipe, slot1.item);
      int material2Count = CountOcurrences(recipe, slot2.item);
      if (material1Count <= slot1.itemStack.Count && material2Count <= slot2.itemStack.Count)
      {
        for (int i = 0; i < material1Count; i++)
        {
          slot1.itemStack.Pop();
        }
        for (int i = 0; i < material2Count; i++)
        {
          slot2.itemStack.Pop();
        }

        CraftItem(recipe);

        if (slot2.itemStack.Count < 1)
          slot2.RemoveItem();
        if (slot1.itemStack.Count < 1)
          slot1.RemoveItem();
      }
      else
      {
        Debug.Log("Not enough materials");
      }

    }
    else
    {
      Debug.Log("No Recipe Found");
    }
  }

  private void CraftItem(CraftingRecipe recipe)
  {
    List<int> availableSlots = CheckAvailableSlots();
    if (availableSlots.Count >= 3)
    {
      Stack<Item> stack = new Stack<Item>();
      stack.Push(recipe.craftedItem);
      AddItemToSlot(availableSlots[0], stack);
      inventory.AddAt(availableSlots[0], stack);

      inventory.itemEvent.Raise();
      stackedEvent.Raise();
    }
    else
    {
      Debug.Log("Not enough open slots");
    }
  }

  void AddItemToSlot(int index, Stack<Item> stack)
  {
    foreach (Slot slot in inventorySlots)
    {
      if (slot.itemIndex == index)
        slot.AddItem(stack);
    }
  }

  int CountOcurrences(CraftingRecipe recipe, Item item)
  {
    int count = 0;
    foreach (Item i in recipe.materialList)
    {
      if (i == item)
        count++;
    }
    return count;
  }

  CraftingRecipe CheckMaterials()
  {
    bool containsMaterial1 = false;
    bool containsMaterial2 = false;
    CraftingRecipe foundRecipe = null;

    foreach (CraftingRecipe recipe in list.recipesList)
    {
      containsMaterial1 = recipe.materialList.Contains(slot1.item);
      containsMaterial2 = recipe.materialList.Contains(slot2.item);

      if (containsMaterial1 && containsMaterial2)
      {
        foundRecipe = recipe;
      }
    }

    return foundRecipe;
  }

  public List<int> CheckAvailableSlots()
  {
    var available = new List<int>();
    for (int i = 0; i <= inventory.Items.Count - 1; i++)
    {
      if (inventory.Items[i] == null) available.Add(i);
    }
    return available;
  }

}
