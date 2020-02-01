using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] Character character;
    [SerializeField] StatPanel statPanel;

    private void Awake () {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;

    }

    private void EquipFromInventory (Item item) {
        if (item is EquippableItem) {
            Equip ((EquippableItem) item);
        }
    }

    private void UnequipFromEquipPanel (Item item) {
        if (item is EquippableItem) {
            Unequip ((EquippableItem) item);
        }
    }

    public void Equip (EquippableItem item) {
        if (inventory.RemoveItem (item)) {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem (item, out previousItem)) {
                if (previousItem != null) {
                    inventory.AddItem (previousItem);
                    previousItem.Unequip (character);
                    statPanel.UpdateStatValues ();
                }
                item.Equip (character);

                statPanel.UpdateStatValues ();
            } else {
                inventory.AddItem (item);
            }
        }
    }

    public void Unequip (EquippableItem item) {
        if (!inventory.IsFull () && equipmentPanel.RemoveItem (item)) {
            item.Unequip (character);
            statPanel.UpdateStatValues ();
            inventory.AddItem (item);
        }
    }
}