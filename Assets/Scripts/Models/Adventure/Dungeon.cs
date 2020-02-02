using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dungeon : ScriptableObject
{
    public int id;
    public string name;
    public string desc;
    public Enemy[] Enemies;
    private System.Random random = new System.Random ();

    public Enemy ReturnRandomEnemy() {
        int index = random.Next (Enemies.Length);
        Debug.Log("Returning the enemy: " + Enemies[index].ToString());
        return Enemies[index];
    }
}
