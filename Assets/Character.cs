using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    //character is where the main player details are stored. Some things will need to be moved here. It joins the inventoryManager to the statPanels.
    public AdventureStat PhysicalAttack;
    public AdventureStat PhysicalDefense;
    public AdventureStat MagicalAttack;
    public AdventureStat MagicalDefense;

    int PhysicalAttackLevel;
    int PhysicalDefenseLevel;
    int MagicalAttackLevel;
    int MagicalDefenseLevel;

    [SerializeField] StatPanel[] statPanels;
    [SerializeField] private UI_Harem uiHarem;
    public HaremStorage haremStorage;

    private void Awake () {
        for (int i = 0; i < statPanels.Length; i++) {
        statPanels[i].SetStats (PhysicalAttack, PhysicalDefense, MagicalAttack, MagicalDefense);
        statPanels[i].UpdateStatValues ();
        }
        uiHarem.setHaremStorage (haremStorage);
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