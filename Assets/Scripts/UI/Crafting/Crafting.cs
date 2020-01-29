using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour
{

    [SerializeField]
    InventoryList inventory = null;

    [SerializeField]
    List<Slot> inventorySlots = null;

    [SerializeField]
    GameEvent stackedEvent = null;

    [SerializeField]
    CraftingRecipe recipe = null;

    [SerializeField]
    TextMeshProUGUI stackText = null;

    [SerializeField]
    Button craftButton = null;

    List<Stack<Item>> inventoryMaterials = null;

    List<Stack<CraftingMaterial>> recipeMaterials = null;

    public float craftingAmount = 0;

    void Awake()
    {
        recipeMaterials = new List<Stack<CraftingMaterial>>();
        LoadRecipeMaterials();
    }

    void Update()
    {
        inventoryMaterials = GetInventoryMaterials();
        if (recipeMaterials != null)
            craftingAmount = GetCraftAmount();
        stackText.text = craftingAmount.ToString();
        if (craftingAmount == 0)
        {
            craftButton.interactable = false;
            stackText.enabled = false;
        }
        else
        {
            craftButton.interactable = true;
            stackText.enabled = true;
        }
    }

    void LoadRecipeMaterials()
    {
        foreach (CraftingMaterial material in recipe.materialList)
        {
            var materials = recipe.materialList.FindAll(m => m == material);
            Stack<CraftingMaterial> stack = new Stack<CraftingMaterial>();
            for (int i = 0; i < materials.Count; i++)
            {
                stack.Push(material);
            }
            if (stack != null)
                recipeMaterials.Add(stack);
        }
    }

    public void DoCraft()
    {
        if (craftingAmount > 0)
            CraftItem(recipe);
    }

    float GetCraftAmount()
    {
        float lowestCount = Mathf.Infinity;
        List<float> materialCount = new List<float>();
        foreach (Stack<CraftingMaterial> material in recipeMaterials)
        {
            foreach (Stack<Item> stack in inventoryMaterials)
            {
                float count = Mathf.Infinity;
                if (stack.Peek() == material.Peek())
                {
                    count = stack.Count / material.Count;
                    if (count < lowestCount) lowestCount = count;
                    materialCount.Add(count);
                }

            }
        }
        if (materialCount.Count == recipeMaterials.Count)
        {
            if (lowestCount == Mathf.Infinity)
            {
                return 0f;
            }
            else
            {
                return lowestCount;
            }
        }
        else
        {
            return 0f;
        }
    }

    List<Stack<Item>> GetInventoryMaterials()
    {
        List<Stack<Item>> list = new List<Stack<Item>>();
        foreach (Stack<Item> stack in inventory.Items)
        {
            if (stack != null && stack.Count > 0 && stack.Peek() is CraftingMaterial) list.Add(stack);
        }
        return list;
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

            SpendMaterials();

            inventory.itemEvent.Raise();
            stackedEvent.Raise();
        }
        else
        {
            Debug.Log("Not enough open slots");
        }
    }

    void SpendMaterials()
    {
        foreach (Stack<CraftingMaterial> stack in recipeMaterials)
        {
            for (var i = 0; i < inventoryMaterials.Count; i++)
            {
                if (inventoryMaterials[i] != null && inventoryMaterials[i].Peek() == stack.Peek())
                {
                    inventoryMaterials[i].Pop();
                    if (inventoryMaterials[i].Count == 0)
                    {
                        inventoryMaterials[i] = null;
                    }
                }
            }
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
