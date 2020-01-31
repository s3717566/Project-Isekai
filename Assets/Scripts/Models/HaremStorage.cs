using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaremStorage {

    public event EventHandler OnHaremListChanged;

    private List<Member> haremList;

    public HaremStorage () {
        haremList = new List<Member> ();

        haremList.Add (new Member (1, "z2", "ooga booga"));
        haremList.Add (new Member (2, "anime girl", "ooga booga"));
        Debug.Log ("harem list count: " + haremList.Count);

    }

    public void addToHarem (Member member) {
        haremList.Add (member);
        OnHaremListChanged.Invoke (this, EventArgs.Empty);
        Debug.Log ("Added " + member.ToString () + " to list");
    }

    public List<Member> getHaremList () {
        return haremList;
    }

    public void debugAll() {
        foreach (Member m in haremList) {
            Debug.Log("in the harem storage: " + m.ToString());
        }
    }
}