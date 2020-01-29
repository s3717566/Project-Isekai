using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform inventoryHolder;
    private bool enabled = false;

    public void setInventory (Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        refreshInventoryItems ();
    }

    private void Inventory_OnItemListChanged (object sender, System.EventArgs e) {
        Debug.Log ("Inventory_OnItemListChanged triggered");
        refreshInventoryItems ();
    }

    private void Awake () {
        inventoryHolder = transform;
        itemSlotContainer = transform.Find ("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find ("itemSlotTemplate");
    }

    void OnEnable () {
        Debug.Log ("inventory enabled");
        enabled = true;
        refreshInventoryItems ();
    }

    void OnDisable () {
        Debug.Log ("inventory disabled");
        enabled = false;
    }

    private void refreshInventoryItems () {
        if (enabled) {
            foreach (Transform child in itemSlotContainer) {
                if (child == itemSlotTemplate) {
                    continue;
                } else {
                    Destroy (child.gameObject);
                }
            }

            foreach (Item item in inventory.getInventoryList ()) {
                RectTransform itemSlotRectTransform = Instantiate (itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform> ();
                itemSlotRectTransform.gameObject.SetActive (true);

                Image image = itemSlotRectTransform.Find ("icon").GetComponent<Image> ();
                image.sprite = item.getSprite ();
            }
        } else {
            Debug.Log ("Inventory holder not active");
        }
    }
}