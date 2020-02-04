using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : BaseItemSlot, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler {

    //item slot are the empty slots where items are held. This is a UI and interaction component. Interactions such as clicking are registered here but the logic for the interactions is done in another class.
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private Color dragColor = new Color(1,1,1,0.5f);

    public override bool CanReceiveItem (Item item) {
        return true;
    }

    public void OnBeginDrag (PointerEventData eventData) {
        if (OnBeginDragEvent != null) {
            OnBeginDragEvent (this);
        }
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (OnEndDragEvent != null) {
            OnEndDragEvent (this);
        }
    }

    public void OnDrag (PointerEventData eventData) {
        if (OnDragEvent != null) {
            OnDragEvent (this);
        }
    }

    public void OnDrop (PointerEventData eventData) {
        if (OnDropEvent != null) {
            OnDropEvent (this);
        }
    }
}