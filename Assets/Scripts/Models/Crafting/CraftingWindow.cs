using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWindow : MonoBehaviour
{
    //full logic
    /*

    */

    [Header("References")]
    //in this case its just an item slot, nothing fancy (make prefab later)
    [SerializeField] CraftingRecipeUI recipeUIPrefab;
    [SerializeField] BaseItemSlot baseItemSlotPrefab;

    //will need 3 parents maybe
    [SerializeField] RectTransform recipeUIParent; //parent of all the recipeUI, so "content" in pnl Recipes
    [SerializeField] List<CraftingRecipeUI> craftingRecipeUIs;

    //put the two transform thingies here
    [SerializeField] Transform RequirementSlotHolder;
    [SerializeField] Transform OutputSlotHolder;
    [SerializeField] Transform ButtonHolder;

    [Header("Public Variables")]
    public ItemContainer ItemContainer;
    public List<Recipe> CraftingRecipes;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;

    private void OnValidate()
    {
        Init();
    }

    private void Start()
    {
        Init();

        foreach (CraftingRecipeUI craftingRecipeUI in craftingRecipeUIs)
        {
            //craftingRecipeUI.OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            //craftingRecipeUI.OnPointerExitEvent += slot => OnPointerExitEvent(slot);
        }
    }

    private void Init()
    {
        recipeUIParent.GetComponentsInChildren<CraftingRecipeUI>(includeInactive: true, result: craftingRecipeUIs);
        //ButtonHolder = transform.Find("btnCraft");

        UpdateCraftingRecipes();
    }

    public void UpdateCraftingRecipes()
    {
        for (int i = 0; i < CraftingRecipes.Count; i++)
        {
            if (craftingRecipeUIs.Count == i)
            {
                craftingRecipeUIs.Add(Instantiate(recipeUIPrefab, recipeUIParent, false));
                //create the UI object here to the list apparently
            }
            else if (craftingRecipeUIs[i] == null)
            {
                craftingRecipeUIs[i] = Instantiate(recipeUIPrefab, recipeUIParent, false);
            }
            craftingRecipeUIs[i].setTransforms(RequirementSlotHolder, OutputSlotHolder, ButtonHolder, baseItemSlotPrefab);

            craftingRecipeUIs[i].ItemContainer = ItemContainer;
            craftingRecipeUIs[i].CraftingRecipe = CraftingRecipes[i];
        }

        //for (int i = CraftingRecipes.Count; i < craftingRecipeUIs.Count; i++)
        //{
        //    craftingRecipeUIs[i].CraftingRecipe = null;
        //}
    }
}