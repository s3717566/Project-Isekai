using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public class Item {
    public int id;
    public string name;
    public ItemType itemType;
    public string desc;
    public int amount;
    public Sprite sprite = IconController.Instance.castleSprite;

    public enum ItemType {
        Weapon,
        Helmet,
        Chestplate,
        Leggings,
        Boots,
        MobDrop,
    }

    public Sprite getSprite() {
        return sprite;
    }

    public Item (int id, string name, string desc, ItemType itemType, int amount, Sprite sprite) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.itemType = itemType;
        this.amount = amount;
        this.sprite = sprite;
    }

    public string getName() {
        return name;
    }

    public override string ToString() {
        return "id: " + id + ", name: " + name;
    }

    public bool isStackable() {
        switch (itemType) {
            case ItemType.MobDrop: return true;
            default: return false;
        }
    }
}