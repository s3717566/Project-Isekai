using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gacha : MonoBehaviour {
    //Refers to the gacha controller instance.
    public GachaController gachaController;

    //Refers to the one instance of harem Storage being used in game
    public HaremStorage haremStorage;

    //Refers to the UI Object this script is attached to (currently named DisplayUnlockables, inside the GachaHolder)
    private Transform displayUnlockablesTransform;

    //Refers to profileTemplate inside DisplayUnlockables. Cloned many times.
    private Transform profileTemplate;
    private bool enabled;

    private void Awake() {
        displayUnlockablesTransform = transform;
        profileTemplate = displayUnlockablesTransform.Find("profileTemplate");
        gachaController.setValues(haremStorage, profileTemplate, displayUnlockablesTransform);
        gachaController.displayUnlockables();
    }

    private void OnEnable() {
        enabled = true;
    }

    private void OnDisable() {
        enabled = false;

        //Refreshes the roster of unlockable members.
        gachaController.refreshUnlockables();
    }
}