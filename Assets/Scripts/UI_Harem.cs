using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;


public class UI_Harem : MonoBehaviour {
    private HaremStorage haremStorage;
    private Transform haremContent;
    private Transform profileTemplate;
    private bool enabled;

    public void setHaremStorage (HaremStorage haremStorage) {
        haremStorage.debugAll();
        this.haremStorage = haremStorage;
        Debug.Log ("storage set successfully");
        haremStorage.OnHaremListChanged += Harem_OnHaremListChanged;
        Debug.Log ("weird onclick thing done");
        refreshHarem ();
        Debug.Log ("harem set and refreshed");

    }

    private void Harem_OnHaremListChanged (object sender, System.EventArgs e) {
        Debug.Log ("Harem_OnHaremListChanged triggered");
        refreshHarem ();
    }

    private void Awake () {
        Debug.Log("UI_HAREM is trying to wake up");
        haremContent = transform;
        profileTemplate = haremContent.Find ("profileTemplate");
        Debug.Log("UI_HAREM has awoken");
    }

    void OnEnable () {
        Debug.Log ("harem enabled");
        enabled = true;
        refreshHarem();
    }

    void OnDisable () {
        Debug.Log ("harem disabled");
        enabled = false;
    }

    private void refreshHarem () {
        if (enabled) {
            foreach (Transform child in haremContent) {
                Debug.Log ("Child: " + child);
                if (child == profileTemplate) {
                    continue;
                } else {
                    Destroy (child.gameObject);
                }
            }

            foreach (Member member in haremStorage.getHaremList ()) {
                if (member.Name.Equals("02")) {
                    continue;
                }
                Debug.Log ("Cloning profile template");

                //Get rectangle that displays info for a waifu
                RectTransform itemSlotRectTransform = Instantiate (profileTemplate, haremContent).GetComponent<RectTransform> ();
                itemSlotRectTransform.gameObject.SetActive (true);

                //Get image display and set to resource image
                Image image = itemSlotRectTransform.Find ("imgProfile").GetComponent<Image> ();
                image.sprite = member.Sprite;

                //Get text display and set to waifu name
                Text text = itemSlotRectTransform.Find ("txtProfile").GetComponent<Text>();
                text.text = member.Name;
            }
        }
    }
}