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
        inventoryList.Add (item);
        OnItemListChanged.Invoke(this, EventArgs.Empty);
        Debug.Log("Added " + item.ToString() + " to list");
    }

    public List<Item> getInventoryList () {
        return inventoryList;
    }
}