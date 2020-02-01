using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaremStorage {

    public event EventHandler OnHaremListChanged;

    private List<Member> haremList;

    public HaremStorage () {
        haremList = new List<Member> () {
            new Member(1, "02", "Dino girl"),
            new Member(2, "Yaoyorozu", "Best girl"),
            new Member(3, "Aqua", "Useless girl"),
            new Member(4, "Raphtalia", "Raccoon girl"),
        };

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