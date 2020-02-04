using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] Text amountText;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color (1, 1, 1, 0);

    public Item _item;
    public Item Item {
        get { return _item; }
        set {
            _item = value;

            if (_item == null) {
                image.color = disabledColor;
            } else {
                image.sprite = _item.Icon;
                image.color = normalColor;
            }
        }
    }
    private int _amount;
    public int Amount {
        get { return _amount; }
        set {
            _amount = value;
            amountText.enabled = _item != null && _item.MaximumStacks > 1 && _amount > 1;
            if (amountText.enabled) {
                amountText.text = _amount.ToString();
            }
        }
    }

    protected virtual void OnValidate () {
        if (image == null) {
            image = GetComponent<Image> ();
        }
                if (amountText == null) {
            amountText = GetComponentInChildren<Text> ();
        }
    }

    public virtual bool CanReceiveItem (Item item) {
        return false;
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right) {
            if (OnRightClickEvent != null) {
                OnRightClickEvent (this);
            }
        }
    }

    public void OnPointerEnter (PointerEventData eventData) {
        if (OnPointerEnterEvent != null) {
            OnPointerEnterEvent (this);
        }
    }

    public void OnPointerExit (PointerEventData eventData) {
        if (OnPointerExitEvent != null) {
            OnPointerExitEvent (this);
        }
    }
}
