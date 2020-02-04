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

    public void loseHealthCalc (AdventureStat pdmg, AdventureStat mdmg) {
        double ptotal = pdmg.Value - PhysicalDefense.Value;
        double mtotal = mdmg.Value - MagicalDefense.Value;
        if (ptotal > 0) {
            Health -= ptotal;
            // Debug.Log ("Enemy took " + ptotal + " p dmg");
        }
        if (mtotal > 0) {
            Health -= mtotal;
            // Debug.Log ("Enemy took " + mtotal + " m dmg");
        }
    }

    public override string ToString () {
        return "name: " + Name + ", id: " + Id;
    }

    public void regen () {
        Health += HealthRegen;
    }

    public void setHealth (double health) { this.Health = health; }
    public void loseHealth (double health) { this.Health -= health; }
    public void gainHealth (double health) { this.Health += health; }

}