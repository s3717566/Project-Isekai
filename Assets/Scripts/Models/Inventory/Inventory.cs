using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : ItemContainer, IItemContainer {

    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private void Start () {
        for (int i = 0; i < itemSlots.Length; i++) {
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }
        SetStartingItems ();
    }
    private void OnValidate () {
        if (itemsParent != null) {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot> ();
        }

        SetStartingItems ();
    }

    //only for debugging purposes
    private void SetStartingItems () {
        int i = 0;
        for (; i < startingItems.Count && i < itemSlots.Length; i++) {
            itemSlots[i].Item = startingItems[i].GetCopy ();
            itemSlots[i].Amount = 1;
        }

        for (; i < itemSlots.Length; i++) {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }
    }
}