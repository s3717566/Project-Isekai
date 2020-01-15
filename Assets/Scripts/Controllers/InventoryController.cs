using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController instance;
    public List<ItemStack> inventory; 

    void Start() {
        if (instance != null) {
            Debug.log("InventoryController can only have one instance!");
            return;
        }
        instance = this;
    }

    public void AddItemToInventory(ItemStack itemStack) {
        bool hasItem = false;

        foreach (ItemStack i in inventory) {
            if (i.item.name == itemStack.item.name);
            i.amount += itemStack.amount;
            hasItem = true;
        }
        if (!hasItem) {
            inventory.Add(itemStack);
        }
    }
}
