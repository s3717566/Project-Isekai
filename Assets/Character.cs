using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public AdventureStat PhysicalAttack;
    public AdventureStat PhysicalDefense;
    public AdventureStat MagicalAttack;
    public AdventureStat MagicalDefense;

    [SerializeField] StatPanel statPanel;

    private void Awake () {
        PhysicalAttack.AddModifier(new StatModifier(5, StatModType.Flat) );
        statPanel.SetStats (PhysicalAttack, PhysicalDefense, MagicalAttack, MagicalDefense);
        statPanel.UpdateStatValues ();
    }

    public void Equip(EquippableItem item) {
        item.Equip(this);
    }

    public void Unequip(EquippableItem item) {
        item.Unequip(this);
    }
}