using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavController : MonoBehaviour
{
    public GameObject activeTab;

    public void ShowPanel(Transform activateTab)
    {
        activeTab.SetActive(false);
        activeTab = activateTab.gameObject;
        activeTab.SetActive(true);
    }
}

