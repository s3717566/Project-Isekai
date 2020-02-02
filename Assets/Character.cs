using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public AdventureStat PhysicalAttack;
    public AdventureStat PhysicalDefense;
    public AdventureStat MagicalAttack;
    public AdventureStat MagicalDefense;

    [SerializeField] StatPanel[] statPanels;

    private void Awake () {
        for (int i = 0; i < statPanels.Length; i++) {
        statPanels[i].SetStats (PhysicalAttack, PhysicalDefense, MagicalAttack, MagicalDefense);
        statPanels[i].UpdateStatValues ();
        }
    }

    public void Equip(EquippableItem item) {
        item.Equip(this);
    }

    public void Unequip(EquippableItem item) {
        item.Unequip(this);
    }

    public void UpdateStatPanels() {
        for (int i = 0; i < statPanels.Length; i++) {
        statPanels[i].UpdateStatValues ();
        }
    }
}