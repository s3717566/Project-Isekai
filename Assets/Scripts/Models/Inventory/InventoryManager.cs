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

    private ItemSlot draggedSlot;

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

    private void Equip (ItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            Equip (item);
        }
    }

    private void Unequip (ItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            Unequip (item);
        }
    }

    private void ShowTooltip (ItemSlot itemSlot) {
        EquippableItem item = itemSlot.Item as EquippableItem;
        if (item != null) {
            // itemTooltip.ShowTooltip(EquippableItem);
        }
    }

    private void HideTooltip (ItemSlot itemSlot) {
        // itemTooltip.HideTooltip();
    }

    private void BeginDrag (ItemSlot itemSlot) {
        if (itemSlot.Item != null) {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag (ItemSlot itemSlot) {
        draggedSlot = null;
        draggableItem.enabled = false;

    }

    private void Drag (ItemSlot itemSlot) {
        if (draggableItem.enabled) {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop (ItemSlot dropItemSlot) {
        if (dropItemSlot.CanReceiveItem (draggedSlot.Item) && draggedSlot.CanReceiveItem (dropItemSlot.Item)) {
            EquippableItem dragItem = draggedSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if (draggedSlot is EquipmentSlot) {
                if (dragItem != null) dragItem.Unequip (character);
                if (dropItem != null) dropItem.Equip (character);

            }
            if (dropItemSlot is EquipmentSlot) {
                if (dragItem != null) dragItem.Equip (character);
                if (dropItem != null) dropItem.Unequip (character);
            }
                character.UpdateStatPanels ();

            Item draggedItem = draggedSlot.Item;
            draggedSlot.Item = dropItemSlot.Item;
            dropItemSlot.Item = draggedItem;
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