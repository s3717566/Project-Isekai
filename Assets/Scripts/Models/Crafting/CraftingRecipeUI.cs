using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeUI : MonoBehaviour
{
    //[Header("References")]
    //these will be passed to it by parent script
    BaseItemSlot[] requirementSlots;
    BaseItemSlot[] outputSlots;
    Button craftButton;

    //this doesnt need to be an array
    BaseItemSlot recipeSlot;

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
    [Header("Public Variables")]
    public ItemContainer ItemContainer;

    private Recipe craftingRecipe;
    public Recipe CraftingRecipe
    {
        get { return craftingRecipe; }
        set { SetCraftingRecipe(value); }
    }

    public void setTransforms(Transform RequirementSlotHolder, Transform OutputSlotHolder, Transform ButtonTransform, BaseItemSlot baseItemSlot)
    {
        requirementSlots = RequirementSlotHolder.GetComponentsInChildren<BaseItemSlot>(includeInactive: true);
        outputSlots = OutputSlotHolder.GetComponentsInChildren<BaseItemSlot>(includeInactive: true);
        craftButton = ButtonTransform.GetComponent<Button>();
        setButton();
        //baseItemSlotPrefab = baseItemSlot;
    }
    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;

    private void OnValidate()
    {
        recipeSlot = transform.GetComponent<BaseItemSlot>();
    }

    private void setButton()
    {
        craftButton.onClick.RemoveAllListeners();
        craftButton.onClick.AddListener(OnCraftButtonClick);
    }

    private void Start()
    {
        //for the tooltips
        /*
        foreach (BaseItemSlot itemSlot in materialSlots) {
            itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
            itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
        }

               foreach (BaseItemSlot itemSlot in resultSlots) {
            itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
            itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
        }

                foreach (BaseItemSlot itemSlot in recipeSlots) {
             itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent (slot);
             itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent (slot);
         }
         */
    }


    //this button needs to be passed in from the crafting window as well
    public void OnCraftButtonClick()
    {
        Debug.Log("You have clicked the crafting button");
        if (craftingRecipe != null && ItemContainer != null)
        {
            craftingRecipe.Craft(ItemContainer);
        }
    }

    private void SetCraftingRecipe(Recipe newCraftingRecipe)
    {
        craftingRecipe = newCraftingRecipe;
        UpdateRecipeSlotHolder(craftingRecipe.Results);
    }

    private void setRecipeUI()
    {
        if (craftingRecipe != null)
        {
            //SetSlots (craftingRecipe.Materials, materialSlots);
            // arrowParent.SetSiblingIndex(slotIndex);
            //SetSlots (craftingRecipe.Results,  resultSlots);
            //SetSlots (craftingRecipe.Results,  recipeSlots);

            //sets subsequent slots to inactive - pls fix
            // for (int i = slotIndex; i < materialSlots.Length; i++) {
            //     materialSlots[i].transform.parent.gameObject.SetActive (false);
            // }

            //you could probably do the following part generically and i dont think it would be hard, im too lazy rn
            UpdateRequirementSlotHolder(craftingRecipe.Materials);
            UpdateOutputSlotHolder(craftingRecipe.Results);
            setButton();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void clickSelected()
    {
        setRecipeUI();
    }

    public void UpdateRequirementSlotHolder(IList<ItemAmount> itemAmountList)
    {
        int i = 0;
        for (; i < itemAmountList.Count; i++)
        {
            ItemAmount itemFromRecipe = itemAmountList[i]; //array from recipe
            BaseItemSlot itemSlot = requirementSlots[i]; //array from transform

            //main logic
            itemSlot.Item = itemFromRecipe.Item;
            itemSlot.Amount = itemFromRecipe.Amount;
            itemSlot.gameObject.SetActive(true);
        }

        for (; i < requirementSlots.Length; i++)
        {
            BaseItemSlot itemSlot = requirementSlots[i]; //array from transform
            itemSlot.gameObject.SetActive(false);
        }
    }

    public void UpdateOutputSlotHolder(IList<ItemAmount> itemAmountList)
    {
        //for (int i = 0; i < 1; i++) { //there is only 1 output slot, but since its a list i thought i better keep the capability to output a list there
        ItemAmount itemFromRecipe = itemAmountList[0]; //array from recipe
        BaseItemSlot itemSlot = outputSlots[0]; //array from transform

        //main logic
        itemSlot.Item = itemFromRecipe.Item;
        itemSlot.Amount = itemFromRecipe.Amount;
        //itemSlot.transform.parent.gameObject.SetActive (true);
        //}
    }

    public void UpdateRecipeSlotHolder(IList<ItemAmount> itemAmountList)
    {
        BaseItemSlot itemSlot;
        ItemAmount itemFromRecipe = itemAmountList[0];
        if (recipeSlot != null)
        {
            itemSlot = recipeSlot;
            itemSlot.Item = itemFromRecipe.Item;
            itemSlot.Amount = itemFromRecipe.Amount;
        }
        //Debug.Log("setting this item as recipe slot: " + itemFromRecipe.Item.ToString());

        
    }

    public override string ToString()
    {
        return "This CraftingRecipeUI is to make " + craftingRecipe.Results[0];
    }
}