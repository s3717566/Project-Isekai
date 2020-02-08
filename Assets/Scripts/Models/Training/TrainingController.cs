using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    [SerializeField] Character character;
    private int maxClones;

    private int physicalAttackClones;
    private int physicalDefenceClones;
    private int magicalAttackClones;
    private int magicalDefenceClones;

    private int physicalAttackLevel;
    private int physicalDefenceLevel;
    private int magicalAttackLevel;
    private int magicalDefenceLevel;

    private int incrementAmount; //this is the training speed
    void Start()
    {
        incrementAmount = 1;
        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
        maxClones = 1;
    }

    void UpdateEverySecond()
    {
        physicalAttackLevel += (physicalAttackClones * incrementAmount);
        physicalDefenceLevel += (physicalDefenceClones * incrementAmount);
        magicalAttackLevel += (magicalAttackClones * incrementAmount);
        magicalDefenceLevel += (magicalDefenceClones * incrementAmount);
        printAll();
    }

    public bool areClonesFree()
    {
        return (maxClones > (physicalAttackClones + physicalDefenceClones + magicalAttackClones + magicalDefenceClones));
    }

    public void incrementPhysicalAttackClones()
    {
        if (areClonesFree())
        {
            physicalAttackClones++;
        }
    }

    public void incrementPhysicalDefenceClones()
    {
        if (areClonesFree())
        {
            physicalDefenceClones++;
        }
    }

    public void incrementMagicalAttackClones()
    {
        if (areClonesFree())
        {
            magicalAttackClones++;
        }
    }

    public void incrementMagicalDefenceClones()
    {
        if (areClonesFree())
        {
            magicalDefenceClones++;
        }
    }

    public void decrementPhysicalAttackClones()
    {
        if (physicalAttackClones > 0)
        {
            physicalAttackClones--;
        }
    }

    public void decrementPhysicalDefenceClones()
    {
        if (physicalDefenceClones > 0)
        {
            physicalDefenceClones--;
        }
    }

    public void decrementMagicalAttackClones()
    {
        if (magicalAttackClones > 0)
        {
            magicalAttackClones--;
        }
    }

    public void decrementMagicalDefenceClones()
    {
        if (magicalDefenceClones > 0)
        {
            magicalDefenceClones--;
        }
    }

    public void printAll()
    {
        Debug.Log(physicalAttackLevel + physicalDefenceLevel + magicalAttackLevel + magicalDefenceLevel);
    }
}
