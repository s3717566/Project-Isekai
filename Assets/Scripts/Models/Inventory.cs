using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<Item> inventoryList;

    public Inventory () {
        inventoryList = new List<Item> ();

        Debug.Log ("inventory list count: " + inventoryList.Count);

    }

    public void addItem (Item item) {
        if (item.isStackable ()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in inventoryList) {
                if (inventoryItem.id == item.id) {
                    Debug.Log("added quantity of item");
                    //since these items are not new, when it is increased in inventory it is also increased when dropped from mob
                    //would need to create a new object (copy constructor or something else)
                    inventoryItem.amount += 1;
                    // inventoryItem.amount += item.amount;
                    // Debug.Log("new item quantity after adding " + item.amount + ": " + inventoryItem.amount);
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                inventoryList.Add (item);
            }
        } else {
        inventoryList.Add (item);
        }
        OnItemListChanged.Invoke (this, EventArgs.Empty);
        Debug.Log ("Added " + item.ToString () + " to list");
    }

    public List<Item> getInventoryList () {
        return inventoryList;
    }
}