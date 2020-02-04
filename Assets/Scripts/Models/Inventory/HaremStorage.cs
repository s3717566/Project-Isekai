using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HaremStorage : ScriptableObject {

    public event EventHandler OnHaremListChanged;

    public List<Member> members;

    private void Awake () {
        
        }

    public void addToHarem (Member member) {
        members.Add (member);
        OnHaremListChanged.Invoke (this, EventArgs.Empty);
        //Debug.Log ("Added " + member.ToString () + " to list");
    }

    public List<Member> getHaremList () {
        return members;
    }

    public void debugAll() {
        foreach (Member m in members) {
            //Debug.Log("in the harem storage: " + m.ToString());
        }
    }
}