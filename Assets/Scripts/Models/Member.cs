﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member
{
    public int id;
    public string name;
    public string desc;
    public Sprite sprite = IconController.Instance.castleSprite;

    public Sprite getSprite() {
        return sprite;
    }

    public Member (int id, string name, string desc, Sprite sprite) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.sprite = sprite;
    }

        public Member (int id, string name, string desc) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.sprite = IconController.Instance.castleSprite;
    }

    public string getName() {
        return name;
    }

    public override string ToString() {
        return "id: " + id + ", name: " + name;
    }
}
