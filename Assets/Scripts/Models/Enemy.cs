using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject {

    public int Id;
    public string Name;
    public string Desc;
    public int DungeonId;
    [Space]
    public AdventureStat PhysicalAttack;
    public AdventureStat PhysicalDefense;
    public AdventureStat MagicalAttack;
    public AdventureStat MagicalDefense;
    [Space]
    public double MaxHealth;
    public double Health;
    public double HealthRegen;
    [Space]
    public Sprite Sprite;
    public Item ItemDrop;


    // public Enemy (double phyAttack, double phyDefence, double magAttack, double magDefence, double health) : this (0, 0, "defaultname", "defaultdesc", 1, 1, 1, 1, 20, 1, itemDrop) { }

    // public Enemy (int id, int dungeonid, string name, string desc, double phyAttack, double phyDefence, double magAttack, double magDefence, double health, double healthRegen, Item item) {
    //     this.id = id;
    //     this.dungeonid = dungeonid;
    //     this.name = name;
    //     this.desc = desc;
    //     this.phyAttack = phyAttack;
    //     this.phyDefence = phyDefence;
    //     this.magAttack = magAttack;
    //     this.magDefence = magDefence;
    //     this.maxHealth = health;
    //     this.health = health;
    //     this.healthRegen = healthRegen;
    //     this.itemDrop = item;
    // }

    // public void loseHealthCalc (double pdmg, double mdmg) {
    //     double ptotal = pdmg - phyDefence;
    //     double mtotal = mdmg - magDefence;
    //     if (ptotal > 0) {
    //         health -= ptotal;
    //         // Debug.Log ("Enemy took " + ptotal + " p dmg");
    //     }
    //     if (mtotal > 0) {
    //         health -= mtotal;
    //         // Debug.Log ("Enemy took " + mtotal + " m dmg");
    //     }
    // }

    public override string ToString () {
        return "name: " + Name + ", id: " + Id;
    }

    // public void regen () {
    //     health += healthRegen;
    // }

    // public void setHealth (double health) { this.health = health; }
    // public void loseHealth (double health) { this.health -= health; }
    // public void gainHealth (double health) { this.health += health; }

}