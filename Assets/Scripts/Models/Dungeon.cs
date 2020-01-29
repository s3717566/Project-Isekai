using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    int id;
    string name;
    string desc;

    public int getId() { return id; }

    public Dungeon(int id, string name, string desc) {
        this.id = id;
        this.name = name;
        this.desc = desc;
    }

    public string getName() {
        return name;
    }
}
