using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeUI : MonoBehaviour {
    [Header ("References")]
    // [SerializeField] RectTransform arrowParent;
    [SerializeField] BaseItemSlot[] materialSlots;
    [SerializeField] BaseItemSlot[] resultSlots;
    [SerializeField] BaseItemSlot[] recipeSlots;

    /*
    Create (instantiate?) recipeButtons in recipe slots (maybe hard code them in, doesn't sound too bad)
    when a recipebutton is clicked, wipe the old material slots, populate them with the new recipe
    do the same with the result slots (really only 1 slot)
    maybe make the material item slots and the resultsslots children of recipe slots (weird solution)
    maybe make the crafting window control the other slots since they will be children of it and they wont be duplicated, just re written.

best solution i can think of right now:
crafting recipe UI holds all the values needed
crafting recipe UI is attached to only the recipeSlots
The panel requirements is passed through by public reference and accessed by children
the output is passed in by public reference
    */ 
//itemSlots
    [Header ("Public Variables")]
    public ItemContainer ItemContainer;

    private Recipe craftingRecipe;
    public Recipe CraftingRecipe {
        get { return craftingRecipe; }
        set { SetCraftingRecipe (value); }
    }

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;

    private void OnValidate () {
        materialSlots = transform.Find ("pnlRequirements").Find ("Crafting Item Slot").GetComponentsInChildren<BaseItemSlot> (includeInactive: true);
        //is a list but currently UI is suited to only display one output
        // resultSlots = transform.Find ("pnlOutput").Find ("Output Slot").GetComponentsInChildren<BaseItemSlot> (includeInactive: true);
        //same as result slot, its a long way down
        // recipeSlots = transform.Find ("pnlRecipes").Find ("Scroll View").Find ("Viewport").Find ("Content").Find ("Crafting Slot").GetComponentsInChildren<BaseItemSlot> (includeInactive: true);

    }

    private void Start () {
        //for the tooltips
        foreach (BaseItemSlot itemSlot in materialSlots) {
            itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
            itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
        }

               foreach (BaseItemSlot itemSlot in resultSlots) {
            itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
            itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
        }

        //        foreach (BaseItemSlot itemSlot in recipeSlots) {
        //     itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
        //     itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
        // }
    }

    public void OnCraftButtonClick () {
        if (craftingRecipe != null && ItemContainer != null) {
            craftingRecipe.Craft (ItemContainer);
        }
    }

    private void SetCraftingRecipe (Recipe newCraftingRecipe) {
        craftingRecipe = newCraftingRecipe;

        if (craftingRecipe != null) {
            SetSlots (craftingRecipe.Materials, materialSlots);
            // arrowParent.SetSiblingIndex(slotIndex);
            SetSlots (craftingRecipe.Results,  resultSlots);
            SetSlots (craftingRecipe.Results,  recipeSlots);

//sets subsequent slots to inactive - pls fix
            // for (int i = slotIndex; i < materialSlots.Length; i++) {
            //     materialSlots[i].transform.parent.gameObject.SetActive (false);
            // }

            gameObject.SetActive (true);
        } else {
            gameObject.SetActive (false);
        }
    }

    private void SetSlots (IList<ItemAmount> itemAmountList, BaseItemSlot[] baseItemSlots) {
        for (int i = 0; i < itemAmountList.Count; i++) {
            ItemAmount itemAmount = itemAmountList[i];
            BaseItemSlot itemSlot = baseItemSlots[i];

            itemSlot.Item = itemAmount.Item;
            itemSlot.Amount = itemAmount.Amount;
            itemSlot.transform.parent.gameObject.SetActive (true);
        }
    }

    public void clickSelected() {
        Debug.Log(craftingRecipe.ToString());
    }

    
}