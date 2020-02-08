using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LootBox : ScriptableObject
{
    public int Id;
    public string Name;
    public string Desc;
    public Sprite Sprite;

    public List<Member> unlockables;

    public override string ToString() {
        return "id: " + Id + ", name: " + Name;
    }
}
