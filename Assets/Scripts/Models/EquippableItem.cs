using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Weapon,
    Helmet,
    Chestplate,
    Leggings,
    Boots,
    Necklace,
    Earring1,
    Earring2,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int PhysicalAttack;
    public int PhysicalDefense;
    public int MagicalAttack;
    public int MagicalDefense;
    [Space]
    public int PhysicalAttackPercent;
    public int PhysicalDefensePercent;
    public int MagicalAttackPercent;
    public int MagicalDefensePercent;

    public EquipmentType EquipmentType;
}
