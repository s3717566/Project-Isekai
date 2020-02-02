using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] Character character;
    // [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] Image draggableItem;

    private BaseItemSlot dragItemSlot;

    private void OnValidate () {
        // if (itemTooltip == null) {
        //     itemTooltip = FindObjectOfType<ItemTooltip>();
        // }
    }

    private void Awake () {

        // Setup Events:
        // Right Click
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        // Pointer Enter
        // inventory.OnPointerEnterEvent += ShowTooltip;
        // equipmentPanel.OnPointerEnterEvent += ShowTooltip;
        // Pointer Exit
        // inventory.OnPointerExitEvent += HideTooltip;
        // equipmentPanel.OnPointerExitEvent += HideTooltip;
        // Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        // Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        // Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
    }

    private void Equip (BaseItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            Equip (item);
        }
    }

    private void Unequip (BaseItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            Unequip (item);
        }
    }

    private void ShowTooltip (BaseItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            // itemTooltip.ShowTooltip(EquippableItem);
        }
    }

    private void HideTooltip (BaseItemSlot itemSlot) {
        // itemTooltip.HideTooltip();
    }

    private void BeginDrag (BaseItemSlot itemSlot) {
        if (itemSlot.Item != null) {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag (BaseItemSlot itemSlot) {
        dragItemSlot = null;
        draggableItem.enabled = false;

    }

    private void Drag (BaseItemSlot itemSlot) {
        if (draggableItem.enabled) {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop (BaseItemSlot dropItemSlot) {

        if (dragItemSlot == null) return;

        if (dropItemSlot.CanReceiveItem (dragItemSlot.Item) && dragItemSlot.CanReceiveItem (dropItemSlot.Item)) {
            EquippableItem dragItem = dragItemSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if (dragItemSlot is EquipmentSlot) {
                if (dragItem != null) dragItem.Unequip (character);
                if (dropItem != null) dropItem.Equip (character);

            }
            if (dropItemSlot is EquipmentSlot) {
                if (dragItem != null) dragItem.Equip (character);
                if (dropItem != null) dropItem.Unequip (character);
            }
                character.UpdateStatPanels ();

            Item draggedItem = dragItemSlot.Item;
            int draggedItemAmount = dragItemSlot.Amount;
            
            dragItemSlot.Item = dropItemSlot.Item;
            dragItemSlot.Amount = dropItemSlot.Amount;
            
            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }
    }

    public void Equip (EquippableItem item) {
        if (inventory.RemoveItem (item)) {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem (item, out previousItem)) {
                if (previousItem != null) {
                    inventory.AddItem (previousItem);
                    previousItem.Unequip (character);
                    character.UpdateStatPanels ();
                }
                item.Equip (character);

                character.UpdateStatPanels ();
            } else {
                inventory.AddItem (item);
            }
        }
    }

    public void Unequip (EquippableItem item) {
        if (!inventory.IsFull () && equipmentPanel.RemoveItem (item)) {
            item.Unequip (character);
            character.UpdateStatPanels ();
            inventory.AddItem (item);
        }
    }
}