using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Member : ScriptableObject
{
    public int Id;
    public string Name;
    public string Desc;
    public Sprite Sprite;

    public bool unlocked;

    public override string ToString() {
        return "id: " + Id + ", name: " + Name;
    }
}
