using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour {
    public static IconController Instance { get; private set; }

    private void Awake () {
        Instance = this;
        Debug.Log("icon controller has awoken.");
    }

    public Sprite castleSprite;
    public Sprite farmSprite;
    public Sprite shopSprite;
    public Sprite swordSprite;
    public Sprite trainingSprite;
    public Sprite helmetSprite;
    public Sprite chestplateSprite;
    public Sprite leggingsSprite;
    public Sprite bootsSprite;

}