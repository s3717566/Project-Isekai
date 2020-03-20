using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    public event EventHandler OnUIChanged;

    [SerializeField] Character character;
    public int MaxClones;

    public int PhysicalAttackClones;
    public int PhysicalDefenceClones;
    public int MagicalAttackClones;
    public int MagicalDefenceClones;

    private int incrementAmount; //this is the training speed
    void Start()
    {
        incrementAmount = 1;
        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
        MaxClones = 1;
    }

    void UpdateEverySecond()
    {
        character.PhysicalAttackLevel += (PhysicalAttackClones * incrementAmount);
        character.PhysicalDefenceLevel += (PhysicalDefenceClones * incrementAmount);
        character.MagicalAttackLevel += (MagicalAttackClones * incrementAmount);
        character.MagicalDefenceLevel += (MagicalDefenceClones * incrementAmount);
        refreshUI();
        printAll();
    }

    public int ClonesFree()
    {
        return (MaxClones - (PhysicalAttackClones + PhysicalDefenceClones + MagicalAttackClones + MagicalDefenceClones));
    }

    public void incrementPhysicalAttackClones()
    {
        if (ClonesFree() > 0)
        {
            PhysicalAttackClones++;
            refreshUI();
        }
    }

    public void incrementPhysicalDefenceClones()
    {
        if (ClonesFree() > 0)
        {
            PhysicalDefenceClones++;
            refreshUI();
        }
    }

    public void incrementMagicalAttackClones()
    {
        if (ClonesFree() > 0)
        {
            MagicalAttackClones++;
            refreshUI();
        }
    }

    public void incrementMagicalDefenceClones()
    {
        if (ClonesFree() > 0)
        {
            MagicalDefenceClones++;
            refreshUI();
        }
    }

    public void decrementPhysicalAttackClones()
    {
        if (PhysicalAttackClones > 0)
        {
            PhysicalAttackClones--;
            refreshUI();
        }
    }

    public void decrementPhysicalDefenceClones()
    {
        if (PhysicalDefenceClones > 0)
        {
            PhysicalDefenceClones--;
            refreshUI();
        }
    }

    public void decrementMagicalAttackClones()
    {
        if (MagicalAttackClones > 0)
        {
            MagicalAttackClones--;
            refreshUI();
        }
    }

    public void decrementMagicalDefenceClones()
    {
        if (MagicalDefenceClones > 0)
        {
            MagicalDefenceClones--;
            refreshUI();
        }
    }

    public void printAll()
    {
        Debug.Log(character.PhysicalAttackLevel + character.PhysicalDefenceLevel + character.MagicalAttackLevel + character.MagicalDefenceLevel);
    }

    public void refreshUI ()
    {
        OnUIChanged.Invoke(this, EventArgs.Empty);
    }
}
