using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer {
    [SerializeField] protected ItemSlot[] itemSlots;

    public bool AddItem (Item item) {
        Debug.Log ("Adding item");
        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStacks)) {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                Debug.Log ("Added item!");

                return true;
            }
        }
        return false;
    }

    public virtual bool CanAddItem(Item item, int amount = 1)
	{
		int freeSpaces = 0;

		foreach (ItemSlot itemSlot in itemSlots)
		{
			if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
			{
				freeSpaces += item.MaximumStacks - itemSlot.Amount;
			}
		}
		return freeSpaces >= amount;
	}

    public bool IsFull () {
        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item == null) {
                return false;
            }
        }
        Debug.Log ("inventory is full");
        return true;

    }

    public bool RemoveItem (Item item) {
        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item == item) {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0) {
                    itemSlots[i].Item = null;
                }
                return true;
            }
        }
        return false;
    }

    public Item RemoveItem (string itemID) {
        for (int i = 0; i < itemSlots.Length; i++) {
            Item item = itemSlots[i].Item;
            if (item != null && item.ID == itemID) {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0) {
                    itemSlots[i].Item = null;
                }
                return item;
            }
        }
        return null;
    }

    public bool ContainsItem (Item item) {
        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item == item) {
                return true;
            }
        }
        return false;
    }

    public int ItemCount (string itemID) {
        int number = 0;
        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item.ID == itemID) {
                number++;
            }
        }
        return number;
    }
}