using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Random;

public class GachaController : MonoBehaviour {
    //Harem Storage is used almost everywhere in this class. Might as well store as variable.
    private  HaremStorage haremStorage;

    //Same reason as harem storage, gacha controller always refers to the related transforms.
    private Transform originalProfileTemplate;
    private Transform displayUnlockablesTransform;

    public Button btnPurchase;

    public static System.Random random;

    private void Awake() {
        random = new System.Random();
    }

    public void setValues(HaremStorage haremStorage, Transform profileTemplate, Transform displayUnlockablesTransform) {
        this.haremStorage = haremStorage;
        this.originalProfileTemplate = profileTemplate;
        this.displayUnlockablesTransform = displayUnlockablesTransform;
    }

    //This method will display all (or at least like 9) members that are available to get from gacha.
    //Just check if they have unlocked = false.
    public void displayUnlockables() {
        //Because of referencing, the list I make below to hold not unlocked members can't actually remove anything.
        //Hence, I will just store randomIndex values that are unique in this list.
        //As long as randomIndex does not exist in this list, the display unlockables will show unique waifus.
        List<int> uniqueIndexes = new List<int>();
        for (int i = 0; i < 4; i++) {
            RectTransform itemSlotRectTransform = Instantiate(originalProfileTemplate, displayUnlockablesTransform).GetComponent<RectTransform> ();
            itemSlotRectTransform.gameObject.SetActive (true);

            //Get image display and set to resource image 4 times.
            //First store a list of the members available to be purchased from gacha.
            //Get a random member from the list (that hasnt been chosen yet).
            //Then change the image.sprite to be the image of a random member from the list.
            List<Member> notUnlockedMembers = haremStorage.getAllNotUnlocked();
            //keep getting random index until u get a unique one.
            int randomIndex;
            do {
                randomIndex = random.Next(notUnlockedMembers.Count);
                // Debug.Log("Inside the do, got randomIndex: " + randomIndex);
            } while (uniqueIndexes.Contains(randomIndex));
            uniqueIndexes.Add(randomIndex);
            // Debug.Log("Got after doWhile, randomIndex: " + randomIndex);

            Member randomMember = notUnlockedMembers[randomIndex];
            // Debug.Log("Random Member:" + randomMember);

            Image image = itemSlotRectTransform.Find ("imgProfile").GetComponent<Image> ();
            image.sprite = randomMember.Sprite;

            notUnlockedMembers.Remove(randomMember);
        }
        
    }

    public void refreshUnlockables() {
        foreach (Transform child in displayUnlockablesTransform) {
            if (child == originalProfileTemplate) {
                continue;
            } else {
                Destroy(child.gameObject);
            }
        }
        displayUnlockables();
    }

    //Will probably first do some checks e.g. enough money
    //Then roll for each member that isn't unlocked (maybe make a method in harem storage for all that arent unlocked)
    public void buttonPressed() {
        List<Member> notUnlockedMembers = haremStorage.getAllNotUnlocked();
        if (notUnlockedMembers.Count == 0) {
            Debug.Log("You literally have all members. Do you even have a life?");
            return;
        }
        int randomIndex = random.Next(notUnlockedMembers.Count);
        
        notUnlockedMembers[randomIndex].unlocked = true;
        Debug.Log("Unlocked: " + notUnlockedMembers[randomIndex].Name + " and now: " + notUnlockedMembers[randomIndex].unlocked);

        //Remember to call refresh after unlocking, so that if they unlocked a waifu within the display, the display will update
        //to reflect the unlock.
        refreshUnlockables();
    }
}