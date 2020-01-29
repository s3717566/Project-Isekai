using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private List<Item> requiredItems;
    private Item outputItem;

    public Recipe (List<Item> a, Item b)
    {
        this.requiredItems = a;
        this.outputItem = b;
    }

    public List<Item> getRequiredItems()
    {
        return requiredItems;
    }

    public Item getOutputItems()
    {
        return outputItem;
    }

}
