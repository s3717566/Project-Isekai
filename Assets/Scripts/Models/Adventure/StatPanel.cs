using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPanel : MonoBehaviour {
    
    //the stat panel is the UI panel showing all the stats for both player and enemy.
    [SerializeField] StatDisplay[] statDisplays;
    [SerializeField] string[] statNames;
    private AdventureStat[] stats;

    private void OnValidate () {
        statDisplays = GetComponentsInChildren<StatDisplay> ();
        UpdateStatNames ();
    }

    public void SetStats (params AdventureStat[] charStats) {
        stats = charStats;

        if (stats.Length > statDisplays.Length) {
            Debug.LogError ("Not enough stat displays");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++) {
            statDisplays[i].gameObject.SetActive (i < stats.Length);
        }
    }

    public void UpdateStatValues () {
        for (int i = 0; i < stats.Length; i++) {
            statDisplays[i].ValueText.text = stats[i].Value.ToString ();
        }
    }

    public void UpdateStatNames () {
        for (int i = 0; i < statNames.Length; i++) {
            statDisplays[i].NameText.text = statNames[i];
        }
    }
}