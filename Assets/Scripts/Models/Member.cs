using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member
{
    private int id;
    private string name;
    private string desc;
    private Sprite sprite = IconController.Instance.castleSprite;
    private bool unlocked;

    public Member (int id, string name, string desc, Sprite sprite) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.sprite = sprite;
        this.unlocked = false;
    }

        public Member (int id, string name, string desc) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.sprite = IconController.Instance.castleSprite;
        this.unlocked = false;
    }

    public int getId() {
        return id;
    }

    public string getName() {
        return name;
    }

    public string getDesc() {
        return desc;
    }

    public Sprite getSprite() {
        return sprite;
    }

    public bool getUnlocked() {
        return unlocked;
    }

    public void setUnlocked(bool unlocked) {
        this.unlocked = unlocked;
    }

    public override string ToString() {
        return "id: " + id + ", name: " + name;
    }
}
