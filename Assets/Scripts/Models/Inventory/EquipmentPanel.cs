using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] private Transform equipmentSlotsParent;
    [SerializeField] private EquipmentSlot[] equipmentSlots;

    public Sprite Helmet;
    public Sprite Chestplate;
    public Sprite Leggings;
    public Sprite Boots;
    public Sprite Weapon;
    public Sprite Necklace;
    public Sprite Earring;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private void Start()
    {
        //this for loop instantiates all the interaction events.
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            equipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            equipmentSlots[i].OnDragEvent += OnDragEvent;
            equipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
        setplaceHolder();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                placeholderSwitch(equipmentSlots[i]);
                return true;
            }
        }
        return false;
    }

    private void setplaceHolder()
    {
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].Item == null)
                {
                    equipmentSlots[i].transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
                    placeholderSwitch(equipmentSlots[i]);
                }
            }
        }
         
    }

    private void placeholderSwitch(EquipmentSlot e)
    {
        switch (e.EquipmentType)
        {
            case EquipmentType.Helmet:
                e.transform.GetComponent<Image>().sprite = Helmet;
                return;
            case EquipmentType.Chestplate:
                e.transform.GetComponent<Image>().sprite = Chestplate;
                return;
            case EquipmentType.Leggings:
                e.transform.GetComponent<Image>().sprite = Leggings;
                return;
            case EquipmentType.Boots:
                e.transform.GetComponent<Image>().sprite = Boots;
                return;
            case EquipmentType.Weapon:
                e.transform.GetComponent<Image>().sprite = Weapon;
                return;
            case EquipmentType.Necklace:
                e.transform.GetComponent<Image>().sprite = Necklace;
                return;
            case EquipmentType.Earring1:
                e.transform.GetComponent<Image>().sprite = Earring;
                return;
            case EquipmentType.Earring2:
                e.transform.GetComponent<Image>().sprite = Earring;
                return;
        }
    }
}