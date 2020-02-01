using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

    int id;
    int dungeonid;
    string name;
    string desc;
    Texture2D icon;
    Item itemDrop; 

    double phyAttack = 1;
    double phyDefence = 1;
    double magAttack = 1;
    double magDefence = 1;

    double maxHealth = 10;
    double health = 100;
    double healthRegen = 1;

    public Enemy (double a, double b, double c, double d, double e) {
        id = 0;
        name = "default";
        desc = "a boring description";
        phyAttack = a;
        phyDefence = b;
        magAttack = c;
        magDefence = d;
        maxHealth = e;
        health = e;
        healthRegen = 1;
    }

    public Enemy (double a, double b, double c, double d, double e, double f) {
        id = 0;
        name = "default";
        desc = "a boring description";
        phyAttack = a;
        phyDefence = b;
        magAttack = c;
        magDefence = d;
        maxHealth = e;
        health = e;
        healthRegen = f;
    }

    public Enemy(int a, int dungeon, string b, string c, double d, double e, double f, double g, double h, double i) {
        id = a;
        dungeonid = dungeon;
        name = b;
        desc = c;
        phyAttack = d;
        phyDefence = e;
        magAttack = f;
        magDefence = g;
        maxHealth = h;
        health = h;
        healthRegen = i;
    }

        public Enemy(int a, int dungeon, string b, string c, double d, double e, double f, double g, double h, double i, Item item) {
        id = a;
        dungeonid = dungeon;
        name = b;
        desc = c;
        phyAttack = d;
        phyDefence = e;
        magAttack = f;
        magDefence = g;
        maxHealth = h;
        health = h;
        healthRegen = i;
        itemDrop = item;
    }


    // public void loseHealthCalc (double damage, string type) {
    //     if (type == "physical") {
    //         if (damage > phyDefence) {
    //             loseHealth (damage - phyDefence);
    //             Debug.Log ("player attacked enemy with " + damage + " damage and defends with " + phyDefence + "physical defence resulting in damage of " + (damage - phyDefence));
    //             Debug.Log ("enemy has " + health + " health remaining");

    //         }
    //     } else if (type == "magical") {
    //         if (damage > magDefence) {
    //             loseHealth (damage - magDefence);
    //             Debug.Log ("player attacked enemy with " + damage + " damage and defends with " + magDefence + "magical defence resulting in damage of " + (damage - magDefence));
    //             Debug.Log ("enemy has " + health + " health remaining");
    //         }
    //     }
    // }

    public void loseHealthCalc (double pdmg, double mdmg) {
        double ptotal = pdmg - phyDefence;
        double mtotal = mdmg - magDefence;
        if (ptotal > 0) {
            health -= ptotal;
            // Debug.Log ("Enemy took " + ptotal + " p dmg");
        }
        if (mtotal > 0) {
            health -= mtotal;
            // Debug.Log ("Enemy took " + mtotal + " m dmg");
        }
    }

    public override string ToString () {
        return "Current enemy has stats: " + phyAttack + ", " + phyDefence + ", " + magAttack + ", " + magDefence + ", " + maxHealth + ", " + healthRegen;
    }

    public void regen() {
        health += healthRegen;
    }

    public double getPhyAttack () { return phyAttack; }
    public double getPhyDefence () { return phyDefence; }
    public double getMagAttack () { return magAttack; }
    public double getMagDefence () { return magDefence; }
    public double getHealth () { return health; }
    public double getMaxHealth () { return maxHealth; }
    public double getHealthRegen () { return healthRegen; }
    public int getDungeonId () { return dungeonid; }
    public string getName () { return name; }
    public Item getItem() { return itemDrop; }

    public void setHealth (double health) { this.health = health; }
    public void loseHealth (double health) { this.health -= health; }
    public void gainHealth (double health) { this.health += health; }

}