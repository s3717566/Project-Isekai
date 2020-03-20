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
public class EquippableItem : Item {
    public int PhysicalAttackBonus;
    public int PhysicalDefenseBonus;
    public int MagicalAttackBonus;
    public int MagicalDefenseBonus;
    [Space]
    public int PhysicalAttackPercentBonus;
    public int PhysicalDefensePercentBonus;
    public int MagicalAttackPercentBonus;
    public int MagicalDefensePercentBonus;

    public EquipmentType EquipmentType;

    public override Item GetCopy () {
        return Instantiate (this);
    }

    public override void Destroy () {
        Destroy (this);
    }

    public void Equip (Character c) {
        if (PhysicalAttackBonus != 0)
            c.PhysicalAttack.AddModifier (new StatModifier (PhysicalAttackBonus, StatModType.Flat, this));
        if (PhysicalDefenseBonus != 0)
            c.PhysicalDefence.AddModifier (new StatModifier (PhysicalDefenseBonus, StatModType.Flat, this));
        if (MagicalAttackBonus != 0)
            c.MagicalAttack.AddModifier (new StatModifier (MagicalAttackBonus, StatModType.Flat, this));
        if (MagicalDefenseBonus != 0)
            c.MagicalDefence.AddModifier (new StatModifier (MagicalDefenseBonus, StatModType.Flat, this));

        if (PhysicalAttackPercentBonus != 0)
            c.PhysicalAttack.AddModifier (new StatModifier (PhysicalAttackPercentBonus, StatModType.PercentMult, this));
        if (PhysicalDefensePercentBonus != 0)
            c.PhysicalDefence.AddModifier (new StatModifier (PhysicalDefensePercentBonus, StatModType.PercentMult, this));
        if (MagicalAttackPercentBonus != 0)
            c.MagicalAttack.AddModifier (new StatModifier (MagicalAttackPercentBonus, StatModType.PercentMult, this));
        if (MagicalDefensePercentBonus != 0)
            c.MagicalDefence.AddModifier (new StatModifier (MagicalDefensePercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip (Character c) {
        c.PhysicalAttack.RemoveAllModifiersFromSource (this);
        c.PhysicalDefence.RemoveAllModifiersFromSource (this);
        c.MagicalAttack.RemoveAllModifiersFromSource (this);
        c.MagicalDefence.RemoveAllModifiersFromSource (this);

    }
}