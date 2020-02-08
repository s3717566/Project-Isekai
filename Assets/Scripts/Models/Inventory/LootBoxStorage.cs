using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LootBoxStorage : ScriptableObject {
    public List<LootBox> allLootBoxes;

    public void Awake() {

    }

    public void debugAll() {
        foreach (LootBox lootBox in allLootBoxes) {
            Debug.Log(lootBox.ToString());
        }
    }

    public List<LootBox> getAllLootBoxes() {
        return allLootBoxes;
    }
}